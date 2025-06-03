using EcommerceApp.WebUI.Services.ClientCredentialTokenServices;
using System.Net.Http.Headers;
using System.Net;

namespace EcommerceApp.WebUI.Handlers;

public class ClientCredentialTokenHandler(IClientCredentialTokenService _clientCredentialTokenService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetTokenAsync());
        var response = await base.SendAsync(request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            // error message
        }
        return response;
    }
}
