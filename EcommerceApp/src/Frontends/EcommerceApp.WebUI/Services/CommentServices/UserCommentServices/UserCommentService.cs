using EcommerceApp.DtoLayer.CommentDtos.UserCommentDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CommentServices.UserCommentServices;

public class UserCommentService(HttpClient _httpClient) : IUserCommentService
{
    public async Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto)
        => await _httpClient.PostAsJsonAsync<CreateUserCommentDto>("usercomments", userCommentDto);

    public async Task DeleteUserCommentAsync(int id)
        => await _httpClient.DeleteAsync($"usercomments?id={id}");

    public async Task<List<ResultUserCommentDto>> GetAllCommentsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("usercomments");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserCommentDto>>();

        return values;
    }

    public async Task<List<ResultUserCommentDto>> GetAllCommentsByProductIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"usercomments/GetCommentsByProductId?id={id}");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(jsonData);

        return values;
    }

    public async Task<ResultUserCommentDto> GetUserCommentByIdAsync(int id)
    {
        var responseMessage = await _httpClient.GetAsync($"usercomments/{id}");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();

        var value = JsonConvert.DeserializeObject<ResultUserCommentDto>(jsonData);

        return value;
    }

    public async Task ToggleUserCommentStatusAsync(int id)
        => await _httpClient.PatchAsync($"usercomments?id={id}", null);
}
