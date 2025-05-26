using EcommerceApp.Catalog.Dtos.SettingDtos;

namespace EcommerceApp.Catalog.Services.SettingServices;

public interface ISettingService
{
    Task CreateSettingAsync(CreateSettingDto dto);
    Task DeleteSettingAsync(string id);
    Task<List<ResultSettingDto>> GetAllSettingsAsync();
    Task<GetByIdSettingDto> GetByIdSettingAsync(string id);
    Task UpdateSettingAsync(UpdateSettingDto dto);
}
