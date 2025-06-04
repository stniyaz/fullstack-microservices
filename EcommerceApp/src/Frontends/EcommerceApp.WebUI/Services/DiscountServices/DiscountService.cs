using EcommerceApp.DtoLayer.DiscountDtos;

namespace EcommerceApp.WebUI.Services.DiscountServices;

public class DiscountService(HttpClient _httpClient) : IDiscountService
{
    public async Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string code)
    {
        var responseMessage = await _httpClient.GetAsync($"coupons/GetCodeDetailByCode?code={code}");
        var value = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();

        return value;
    }
}
