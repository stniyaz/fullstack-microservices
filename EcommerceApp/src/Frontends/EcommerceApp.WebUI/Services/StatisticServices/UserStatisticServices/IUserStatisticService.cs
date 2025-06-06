namespace EcommerceApp.WebUI.Services.StatisticServices.UserStatisticServices;

public interface IUserStatisticService
{
    Task<int> GetUserCountAsync();
}
