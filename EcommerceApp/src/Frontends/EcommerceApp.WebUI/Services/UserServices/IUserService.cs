using EcommerceApp.DtoLayer.IdentityDtos.AccountDtos;
using EcommerceApp.WebUI.Models;

namespace EcommerceApp.WebUI.Services.UserServices;

public interface IUserService
{
    Task<UserDetailViewModel> GetUserInfoAsync();
    Task<List<ResultUserDto>> GetAllUsersAsync(string userId);
}
