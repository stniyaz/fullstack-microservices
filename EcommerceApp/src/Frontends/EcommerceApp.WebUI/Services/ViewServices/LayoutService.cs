using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;
using EcommerceApp.WebUI.Services.CatalogServices.CategoryServices;
using EcommerceApp.WebUI.Services.CatalogServices.SettingServices;
using Microsoft.AspNetCore.Http.Metadata;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.ViewServices;

public class LayoutService(ISettingService _settingService,
                           ICategoryService _categoryService)
{
    public async Task<List<ResultSettingDto>> GetSettingsAsync()
        => await _settingService.GetAllSettingsAsync();

    public async Task<List<ResultCategoryDto>> GetCategoriesAsync()
        => await _categoryService.GetAllCategoriesAsync();
}
