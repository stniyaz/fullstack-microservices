using EcommerceApp.Catalog.Dtos.SliderDtos;

namespace EcommerceApp.Catalog.Services.SliderServices;

public interface ISliderService
{
    Task<GetByIdSliderDto> GetByIdSliderAsync(string sliderId);
    Task CreateSliderAsync(CreateSliderDto createSliderDto);
    Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
    Task<List<ResultSliderDto>> GetAllSlidersAsync();
    Task DeleteSliderAsync(string sliderId);
}
