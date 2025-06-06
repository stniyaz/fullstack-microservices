using EcommerceApp.DtoLayer.IdentityDtos.AccountDtos;
using EcommerceApp.WebUI.Models;

namespace EcommerceApp.WebUI.Services.UserServices;

public class UserService(HttpClient _httpClient) : IUserService
{
    public async Task<UserDetailViewModel> GetUserInfoAsync()
        => await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/accounts/getuserinfo");

    public async Task<List<ResultUserDto>> GetAllUsersAsync(string id)
        => await _httpClient.GetFromJsonAsync<List<ResultUserDto>>($"/api/accounts/getallusers?userId={id}");
}
