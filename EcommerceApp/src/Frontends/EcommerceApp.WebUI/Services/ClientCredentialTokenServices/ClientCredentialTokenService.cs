using Duende.IdentityModel.Client;
using EcommerceApp.WebUI.Settings;
using IdentityModel.AspNetCore.AccessTokenManagement;

using Microsoft.Extensions.Options;

namespace EcommerceApp.WebUI.Services.ClientCredentialTokenServices;

public class ClientCredentialTokenService : IClientCredentialTokenService
{
    private readonly ServiceApiSettings _serviceApiSettings;
    private readonly HttpClient _httpClient;
    private readonly IClientAccessTokenCache _clientAccessTokenCache;
    private readonly ClientSettings _clientSettings;

    public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
    {
        _serviceApiSettings = serviceApiSettings.Value;
        _httpClient = httpClient;
        _clientAccessTokenCache = clientAccessTokenCache;
        _clientSettings = clientSettings.Value;
    }

    public async Task<string> GetTokenAsync()
    {
        var currentToken = await _clientAccessTokenCache.GetAsync("ecommerceAppToken");

        if (currentToken != null)
        {
            return currentToken.AccessToken;
        }

        var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
        {
            ClientId = _clientSettings.EcommerceAppVisitorClient.ClientId,
            ClientSecret = _clientSettings.EcommerceAppVisitorClient.ClientSecret,
            Address = discoveryEndPoint.TokenEndpoint
        };

        var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
        await _clientAccessTokenCache.SetAsync("ecommerceAppToken", newToken.AccessToken, newToken.ExpiresIn);

        return newToken.AccessToken;
    }
}
