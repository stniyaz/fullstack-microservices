using EcommerceApp.WebUI.Models;

namespace EcommerceApp.WebUI.Services.UserServices;

public interface IUserService
{
    public Task<UserDetailViewModel> GetUserInfoAsync();
}
