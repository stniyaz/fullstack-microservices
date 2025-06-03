using EcommerceApp.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace EcommerceApp.WebUI.Services.CatalogServices.BrandServices;

public class BrandService(HttpClient _httpClient) : IBrandService
{
    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        => await _httpClient.PostAsJsonAsync<CreateBrandDto>("brands", createBrandDto);

    public async Task DeleteBrandAsync(string brandId)
        => await _httpClient.DeleteAsync($"brands?brandId={brandId}");

    public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("brands");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
        return values;
    }

    public async Task<UpdateBrandDto> GetBrandByIdAsync(string brandId)
    {
        var responseMessage = await _httpClient.GetAsync($"brands/{brandId}");
        var value = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();

        return value;
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brands", updateBrandDto);
    }
}
