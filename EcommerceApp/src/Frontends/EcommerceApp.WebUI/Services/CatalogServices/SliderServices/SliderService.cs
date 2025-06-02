using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CatalogServices.SliderServices;

public class SliderService(HttpClient _httpClient) : ISliderService
{
    public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        => await _httpClient.PostAsJsonAsync<CreateSliderDto>("sliders", createSliderDto);

    public async Task DeleteSliderAsync(string sliderId)
        => await _httpClient.DeleteAsync($"sliders?SliderId={sliderId}");

    public async Task<List<ResultSliderDto>> GetAllSlidersAsync()
    {
        var responseMessage = await _httpClient.GetAsync("sliders");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
        return values;
    }

    public async Task<UpdateSliderDto> GetSliderByIdAsync(string sliderId)
    {
        var responseMessage = await _httpClient.GetAsync($"sliders/{sliderId}");
        var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSliderDto>();

        return value;
    }

    public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync<UpdateSliderDto>("sliders", updateSliderDto);
    }
}
