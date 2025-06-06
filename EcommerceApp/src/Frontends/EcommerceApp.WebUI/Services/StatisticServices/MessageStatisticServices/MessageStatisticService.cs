
namespace EcommerceApp.WebUI.Services.StatisticServices.MessageStatisticServices;

public class MessageStatisticService(HttpClient _httpClient) : IMessageStatisticService
{
    public async Task<int> GetTotalUserMessageCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("usermessages/gettotalusermessagecount");
        var value = await responseMessage.Content.ReadFromJsonAsync<int>();

        return value;
    }
}
