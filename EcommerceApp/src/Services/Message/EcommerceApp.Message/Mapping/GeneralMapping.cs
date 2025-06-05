using AutoMapper;
using EcommerceApp.Message.DAL.Entities;
using EcommerceApp.Message.Dtos.UserMessageDtos;

namespace EcommerceApp.Message.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<UserMessage, CreateUserMessageDto>().ReverseMap();
        CreateMap<UserMessage, UpdateUserMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultUserMessageDto>().ReverseMap();
        CreateMap<UserMessage, GetByIdUserMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultInboxUserMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultSendboxUserMessageDto>().ReverseMap();
    }
}
