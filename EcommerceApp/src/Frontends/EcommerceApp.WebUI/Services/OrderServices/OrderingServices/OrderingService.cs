using EcommerceApp.DtoLayer.OrderDtos.OrderingDtos;

namespace EcommerceApp.WebUI.Services.OrderServices.OrderingServices;

public class OrderingService(HttpClient _httpClient) : IOrderingService
{
    public async Task<List<ResultOrderingDto>> GetOrderingsByUserIdAsync(string userId)
    {
        var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingsByUserId?userId={userId}");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDto>>();

        return values;
    }
}
