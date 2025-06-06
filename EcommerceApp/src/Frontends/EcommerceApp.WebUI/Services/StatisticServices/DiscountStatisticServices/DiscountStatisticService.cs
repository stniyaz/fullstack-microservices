
namespace EcommerceApp.WebUI.Services.StatisticServices.DiscountStatisticServices;

public class DiscountStatisticService(HttpClient _httpClient) : IDiscountStatisticService
{
    public async Task<int> GetCouponCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("coupons/getcouponcount");
        var value = await responseMessage.Content.ReadFromJsonAsync<int>();

        return value;
    }
}
