using EcommerceApp.DtoLayer.MessageDtos.UserMessageDtos;

namespace EcommerceApp.WebUI.Services.MessageServices.UserMessageServices;

public class UserMessageService(HttpClient _httpClient) : IUserMessageService
{
    public async Task<List<ResultInboxUserMessageDto>> GetInboxMessagesAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"usermessages/GetInboxMessages?id={id}");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxUserMessageDto>>();

        return values;
    }

    public async Task<List<ResultSendboxUserMessageDto>> GetSendboxMessagesAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"usermessages/GetSendboxMessages?id={id}");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxUserMessageDto>>();

        return values;
    }
}
