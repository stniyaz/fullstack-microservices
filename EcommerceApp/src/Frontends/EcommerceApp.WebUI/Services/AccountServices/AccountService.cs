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
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient, IOptions<ClientSettings> clientSettings)
    {
        _httpContextAccessor = httpContextAccessor;
        _httpClient = httpClient;
        _clientSettings = clientSettings.Value;
    }

    public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

    public async Task<bool> LoginAsync(LoginDto loginDto)
    {
        var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = "http://localhost:5001",
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false,
            }
        });

        var passwordTokenRequest = new PasswordTokenRequest
        {
            ClientId = _clientSettings.EcommerceAppManagerId.ClientId,
            ClientSecret = _clientSettings.EcommerceAppManagerId.ClientSecret,
            UserName = loginDto.Username,
            Password = loginDto.Password,
            Address = discoveryEndpoint.TokenEndpoint
        };

        var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

        var userInfoRequest = new UserInfoRequest
        {
            Token = token.AccessToken,
            Address = discoveryEndpoint.TokenEndpoint
        };

        var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

        ClaimsIdentity calimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(calimsIdentity);

        var authenticationProperties = new AuthenticationProperties();

        authenticationProperties.StoreTokens(new List<AuthenticationToken>()
        {
            new AuthenticationToken
            {
                Name = OpenIdConnectParameterNames.AccessToken,
                Value = token.AccessToken
            },
            new AuthenticationToken
            {
                Name = OpenIdConnectParameterNames.RefreshToken,
                Value = token.RefreshToken
            },
            new AuthenticationToken
            {
                Name = OpenIdConnectParameterNames.ExpiresIn,
                Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
            }
        });

        authenticationProperties.IsPersistent = false;

        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

        return true;
    }
}
