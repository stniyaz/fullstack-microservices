using EcommerceApp.DtoLayer.DiscountDtos;

namespace EcommerceApp.WebUI.Services.DiscountServices;

public class DiscountService(HttpClient _httpClient) : IDiscountService
{
    public async Task<int> GetCouponRateByCodeAsync(string code)
    {
        var responseMessage = await _httpClient.GetAsync($"coupons/GetCouponRateByCode?code={code}");
        var value = await responseMessage.Content.ReadFromJsonAsync<int>();

        return value;
    }

    public async Task<ResultCouponDto> GetCouponByCodeAsync(string code)
    {
        var responseMessage = await _httpClient.GetAsync($"coupons/GetCouponByCode?code={code}");
        var value = await responseMessage.Content.ReadFromJsonAsync<ResultCouponDto>();

        return value;
    }
}
