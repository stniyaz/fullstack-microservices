using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CatalogServices.SettingServices;

public class SettingService(HttpClient _httpClient) : ISettingService
{
    public async Task<List<ResultSettingDto>> GetAllSettingsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("settings");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultSettingDto>>(jsonData);
        return values;
    }

    public async Task<UpdateSettingDto> GetSettingByIdAsync(string settingId)
    {
        var responseMessage = await _httpClient.GetAsync($"settings/{settingId}");
        var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSettingDto>();

        return value;
    }

    public async Task UpdateSettingAsync(UpdateSettingDto updateSettingDto)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync<UpdateSettingDto>("settings", updateSettingDto);
    }
}
