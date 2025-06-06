using AutoMapper;
using EcommerceApp.Message.DAL.Context;
using EcommerceApp.Message.DAL.Entities;
using EcommerceApp.Message.Dtos.UserMessageDtos;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Message.Services.UserMessageServices;

public class UserMessageService(AppDbContext _dbContext, IMapper _mapper) : IUserMessageService
{
    public async Task CreateUserMessageAsync(CreateUserMessageDto dto)
    {
        await _dbContext.Set<UserMessage>().AddAsync(_mapper.Map<UserMessage>(dto));
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserMessageAsync(int id)
    {
        var value = await _dbContext.Set<UserMessage>().FindAsync(id);
        _dbContext.Set<UserMessage>().Remove(value);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ResultUserMessageDto>> GetAllUserMessagesAsync()
        => _mapper.Map<List<ResultUserMessageDto>>(await _dbContext.Set<UserMessage>().ToListAsync());

    public async Task<List<ResultInboxUserMessageDto>> GetInboxMessagesAsync(string id)
    {
        var values = await _dbContext.Set<UserMessage>().Where(x => x.ReceiverId == id).ToListAsync();

        return _mapper.Map<List<ResultInboxUserMessageDto>>(values);
    }

    public async Task<List<ResultSendboxUserMessageDto>> GetSendboxMessagesAsync(string id)
    {
        var values = await _dbContext.Set<UserMessage>().Where(x => x.SenderId == id).ToListAsync();

        return _mapper.Map<List<ResultSendboxUserMessageDto>>(values);
    }

    public async Task<int> GetTotalUserMessageCountAsync()
        => await _dbContext.Set<UserMessage>().CountAsync();

    public async Task<GetByIdUserMessageDto> GetUserMessageByIdAsync(int id)
    {
        var value = await _dbContext.Set<UserMessage>().FindAsync(id);

        return _mapper.Map<GetByIdUserMessageDto>(value);
    }

    public async Task UpdateUserMessageAsync(UpdateUserMessageDto dto)
    {
        var existValue = await _dbContext.Set<UserMessage>().FindAsync(dto.UserMessageId);

        _mapper.Map<UpdateUserMessageDto, UserMessage>(dto, existValue);

        await _dbContext.SaveChangesAsync();
    }
}
