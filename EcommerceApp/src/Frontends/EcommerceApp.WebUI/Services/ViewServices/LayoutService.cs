using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;
using Microsoft.AspNetCore.Http.Metadata;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.ViewServices;

public class LayoutService(IHttpClientFactory _httpClientFactory)
{
    public async Task<List<ResultSettingDto>> GetSettingsAsync()
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

    public async Task<List<ResultCategoryDto>> GetCategoriesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var categoryResponse = await client.GetAsync("https://localhost:7070/api/categories/");
        var categories = new List<ResultCategoryDto>();

        if (categoryResponse.IsSuccessStatusCode)
        {
            var jsonData = await categoryResponse.Content.ReadAsStringAsync();
            categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        }

        return categories;
    }
}
