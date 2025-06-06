
namespace EcommerceApp.WebUI.Services.StatisticServices.CommentStatisticServices;

public class CommentStatisticService(HttpClient _httpClient) : ICommentStatisticService
{
    public async Task<int> GetActiveUserCommentCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetActiveUserCommentCount");
        var value = await responseMessage.Content.ReadFromJsonAsync<int>();

        return value;
    }

    public async Task<int> GetPassiveUserCommentCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetPassiveUserCommentCount");
        var value = await responseMessage.Content.ReadFromJsonAsync<int>();

        return value;
    }

    public async Task<int> GetTotalUserCommentCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetTotalUserCommentCount");
        var value = await responseMessage.Content.ReadFromJsonAsync<int>();

        return value;
    }
}
