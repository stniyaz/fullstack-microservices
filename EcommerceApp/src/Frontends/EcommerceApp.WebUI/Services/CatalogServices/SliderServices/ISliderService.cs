using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;

namespace EcommerceApp.WebUI.Services.CatalogServices.SliderServices;

public interface ISliderService
{
    Task CreateSliderAsync(CreateSliderDto createSliderDto);
    Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
    Task<UpdateSliderDto> GetSliderByIdAsync(string sliderId);
    Task<List<ResultSliderDto>> GetAllSlidersAsync();
    Task DeleteSliderAsync(string sliderId);
}
