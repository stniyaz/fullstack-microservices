using EcommerceApp.DtoLayer.CommentDtos.UserCommentDtos;

namespace EcommerceApp.WebUI.Services.CommentServices.UserCommentServices;

public interface IUserCommentService
{
    Task DeleteUserCommentAsync(int id);
    Task ToggleUserCommentStatusAsync(int id);
    Task<List<ResultUserCommentDto>> GetAllCommentsAsync();
    Task<ResultUserCommentDto> GetUserCommentByIdAsync(int id);
    Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto);
    Task<List<ResultUserCommentDto>> GetAllCommentsByProductIdAsync(string id);
}
