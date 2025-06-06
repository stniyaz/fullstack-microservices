namespace EcommerceApp.WebUI.Services.StatisticServices.DiscountStatisticServices;

public interface IDiscountStatisticService
{
    Task<int> GetCouponCountAsync();
}
