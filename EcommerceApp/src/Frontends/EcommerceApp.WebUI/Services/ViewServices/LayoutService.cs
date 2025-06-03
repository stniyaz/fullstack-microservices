using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;
using EcommerceApp.WebUI.Services.BasketServices;
using EcommerceApp.WebUI.Services.CatalogServices.CategoryServices;
using EcommerceApp.WebUI.Services.CatalogServices.SettingServices;

namespace EcommerceApp.WebUI.Services.ViewServices;

public class LayoutService(ISettingService _settingService,
                           ICategoryService _categoryService,
                           IBasketService _basketService)
{
    public async Task<List<ResultSettingDto>> GetSettingsAsync()
        => await _settingService.GetAllSettingsAsync();

    public async Task<List<ResultCategoryDto>> GetCategoriesAsync()
        => await _categoryService.GetAllCategoriesAsync();

    public async Task<int> GetBasketItemsCountAsync()
        => await _basketService.GetBasketItemCountAsync();
}
