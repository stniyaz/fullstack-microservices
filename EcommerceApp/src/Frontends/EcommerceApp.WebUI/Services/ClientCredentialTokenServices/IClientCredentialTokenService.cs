namespace EcommerceApp.WebUI.Services.ClientCredentialTokenServices;

public interface IClientCredentialTokenService
{
    Task<string> GetTokenAsync();
}
