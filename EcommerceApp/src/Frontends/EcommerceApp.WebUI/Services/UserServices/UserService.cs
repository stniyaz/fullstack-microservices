using EcommerceApp.WebUI.Models;

namespace EcommerceApp.WebUI.Services.UserServices;

public class UserService(HttpClient _httpClient) : IUserService
{
    public async Task<UserDetailViewModel> GetUserInfoAsync()
        => await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/accounts/getuserinfo");
}
