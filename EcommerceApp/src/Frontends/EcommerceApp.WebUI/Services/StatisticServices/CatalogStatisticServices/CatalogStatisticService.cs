
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.StatisticServices.CatalogStatisticServices;

public class CatalogStatisticService(HttpClient _httpClient) : ICatalogStatisticService
{
    public async Task<long> GetBrandCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetBrandCount");
        var value = await responseMessage.Content.ReadFromJsonAsync<long>();

        return value;
    }

    public async Task<long> GetCategoryCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetCategoryCount");
        var value = await responseMessage.Content.ReadFromJsonAsync<long>();

        return value;
    }

    public async Task<string> GetMaxPriceProductNameAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetMaxPriceProductName");
        var value = await responseMessage.Content.ReadAsStringAsync();

        return value;
    }

    public async Task<string> GetMinPriceProductNameAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetMinPriceProductName");
        var value = await responseMessage.Content.ReadAsStringAsync();

        return value;
    }

    public async Task<decimal> GetProductAvgPriceAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetProductsAvgPrice");
        var value = await responseMessage.Content.ReadFromJsonAsync<decimal>();

        return value;
    }

    public async Task<long> GetProductCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("statistics/GetProductCount");
        var value = await responseMessage.Content.ReadFromJsonAsync<long>();

        return value;
    }
}
