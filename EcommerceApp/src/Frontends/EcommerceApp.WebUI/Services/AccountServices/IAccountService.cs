using EcommerceApp.DtoLayer.IdentityDtos.AccountDtos;

namespace EcommerceApp.WebUI.Services.AccountServices;

public interface IAccountService
{
    public string GetUserId { get; }
    public Task<bool> LoginAsync(LoginDto loginDto);
}
