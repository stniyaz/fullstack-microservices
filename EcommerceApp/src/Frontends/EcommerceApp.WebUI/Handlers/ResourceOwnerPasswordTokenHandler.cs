using EcommerceApp.WebUI.Services.AccountServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net;
using System.Net.Http.Headers;

namespace EcommerceApp.WebUI.Handlers;

public class ResourceOwnerPasswordTokenHandler(IHttpContextAccessor _httpContextAccessor,
                                               IAccountService _accountService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            var tokenResponse = await _accountService.GetRefreshToken();
            {
                if (tokenResponse != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            // error message
        }

        return response;
    }
}
