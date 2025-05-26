using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.ViewServices;

public class LayoutService(IHttpClientFactory _httpClientFactory)
{
    public async Task<List<ResultSettingDto>> GetSettings()
    {
        var client = _httpClientFactory.CreateClient();
        var settingResponse = await client.GetAsync("https://localhost:7070/api/settings/");
        List<ResultSettingDto> settings = new List<ResultSettingDto>();

        if (settingResponse.IsSuccessStatusCode)
        {
            var jsonData = await settingResponse.Content.ReadAsStringAsync();
            settings = JsonConvert.DeserializeObject<List<ResultSettingDto>>(jsonData);
        }

        return settings;
    }
}
