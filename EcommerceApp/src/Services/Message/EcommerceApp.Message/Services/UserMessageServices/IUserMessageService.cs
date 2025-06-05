using EcommerceApp.Message.Dtos.UserMessageDtos;

namespace EcommerceApp.Message.Services.UserMessageServices;

public interface IUserMessageService
{
    Task DeleteUserMessageAsync(int id);
    Task CreateUserMessageAsync(CreateUserMessageDto dto);
    Task UpdateUserMessageAsync(UpdateUserMessageDto dto);
    Task<List<ResultUserMessageDto>> GetAllUserMessagesAsync();
    Task<GetByIdUserMessageDto> GetUserMessageByIdAsync(int id);
    Task<List<ResultInboxUserMessageDto>> GetInboxMessagesAsync(string id);
    Task<List<ResultSendboxUserMessageDto>> GetSendboxMessagesAsync(string id);
}
