using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;

namespace EcommerceApp.WebUI.Services.CatalogServices.SettingServices;

public interface ISettingService
{
    Task<List<ResultSettingDto>> GetAllSettingsAsync();
    Task UpdateSettingAsync(UpdateSettingDto updateSettingDto);
    Task<UpdateSettingDto> GetSettingByIdAsync(string settingId);
}
