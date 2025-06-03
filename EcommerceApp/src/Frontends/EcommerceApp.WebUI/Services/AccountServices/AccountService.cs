using Duende.IdentityModel.Client;
using EcommerceApp.DtoLayer.IdentityDtos.AccountDtos;
using EcommerceApp.WebUI.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace EcommerceApp.WebUI.Services.AccountServices;

public class AccountService : IAccountService
{
    private readonly HttpClient _httpClient;
    private readonly ClientSettings _clientSettings;
    private readonly ServiceApiSettings _serviceApiSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient,
                          IOptions<ClientSettings> clientSettings,
                          IOptions<ServiceApiSettings> serviceApiSettings)
    {
        _httpContextAccessor = httpContextAccessor;
        _httpClient = httpClient;
        _clientSettings = clientSettings.Value;
        _serviceApiSettings = serviceApiSettings.Value;
    }

    public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

    public async Task<bool> GetRefreshToken()
    {
        var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

        RefreshTokenRequest refreshTokenRequest = new()
        {
            ClientId = _clientSettings.EcommerceAppManagerClient.ClientId,
            ClientSecret = _clientSettings.EcommerceAppManagerClient.ClientSecret,
            RefreshToken = refreshToken,
            Address = discoveryEndPoint.TokenEndpoint
        };

        var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

        var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            };

        var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();

        var properties = result.Properties;
        properties.StoreTokens(authenticationToken);

        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

        return true;
    }

    public async Task<bool> LoginAsync(LoginDto loginDto)
    {
        var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        var passwordTokenRequest = new PasswordTokenRequest
        {
            ClientId = _clientSettings.EcommerceAppManagerClient.ClientId,
            ClientSecret = _clientSettings.EcommerceAppManagerClient.ClientSecret,
            UserName = loginDto.Username,
            Password = loginDto.Password,
            Address = discoveryEndPoint.TokenEndpoint
        };

        var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

        var userInfoRequest = new UserInfoRequest
        {
            Token = token.AccessToken,
            Address = discoveryEndPoint.UserInfoEndpoint
        };

        var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        var authenticationProperties = new AuthenticationProperties();

        authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });

        authenticationProperties.IsPersistent = false;

        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

        return true;
    }
}