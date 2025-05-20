using EcommerceApp.Cargo.DtoLayer.Dtos.CargoDetailDtos;

namespace EcommerceApp.Cargo.BusinessLayer.Abstract;

public interface ICargoDetailService
{
    Task DeleteAsync(int id);
    Task<List<ResultCargoDetailDto>> GetAllAsync();
    Task<GetByIdCargoDetailDto> GetByIdAsync(int id);
    Task CreateAsync(CreateCargoDetailDto createCargoDetailDto);
    Task UpdateAsync(UpdateCargoDetailDto updateCargoDetailDto);
}
