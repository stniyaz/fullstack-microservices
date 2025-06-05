using EcommerceApp.DtoLayer.MessageDtos.UserMessageDtos;

namespace EcommerceApp.WebUI.Services.MessageServices.UserMessageServices;

public interface IUserMessageService
{
    Task<List<ResultInboxUserMessageDto>> GetInboxMessagesAsync(string id);
    Task<List<ResultSendboxUserMessageDto>> GetSendboxMessagesAsync(string id);
}
