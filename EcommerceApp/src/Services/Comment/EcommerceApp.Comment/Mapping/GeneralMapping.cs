using AutoMapper;
using EcommerceApp.Comment.Dtos.UserCommentDtos;
using EcommerceApp.Comment.Entities;

namespace EcommerceApp.Comment.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<CreateUserCommentDto, UserComment>().ReverseMap();
        CreateMap<UpdateUserCommentDto, UserComment>().ReverseMap();
        CreateMap<ResultUserCommentDto, UserComment>().ReverseMap();
        CreateMap<GetByIdUserCommentDto, UserComment>().ReverseMap();
    }
}
