using AutoMapper;
using EcommerceApp.Comment.Dtos.UserCommentDtos;
using EcommerceApp.Comment.Entities;

namespace EcommerceApp.Comment.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<CreateUserCommentDto, UserComment>();
        CreateMap<UpdateUserCommentDto, UserComment>();
        CreateMap<ResultUserCommentDto, UserComment>();
        CreateMap<GetByIdUserCommentDto, UserComment>();
    }
}
