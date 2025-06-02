using EcommerceApp.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CatalogServices.FeatureServices;

public class FeatureService(HttpClient _httpClient) : IFeatureService
{
    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        => await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);

    public async Task DeleteFeatureAsync(string FeatureId)
        => await _httpClient.DeleteAsync($"features?featureId={FeatureId}");

    public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
    {
        var responseMessage = await _httpClient.GetAsync("features");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
        return values;
    }

    public async Task<UpdateFeatureDto> GetFeatureByIdAsync(string FeatureId)
    {
        var responseMessage = await _httpClient.GetAsync($"features/{FeatureId}");
        var value = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureDto>();

        return value;
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features", updateFeatureDto);
    }
}
