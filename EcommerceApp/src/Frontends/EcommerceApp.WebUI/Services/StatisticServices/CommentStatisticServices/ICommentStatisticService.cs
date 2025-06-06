namespace EcommerceApp.WebUI.Services.StatisticServices.CommentStatisticServices;

public interface ICommentStatisticService
{
    Task<int> GetActiveUserCommentCountAsync();
    Task<int> GetPassiveUserCommentCountAsync();
    Task<int> GetTotalUserCommentCountAsync();
}
