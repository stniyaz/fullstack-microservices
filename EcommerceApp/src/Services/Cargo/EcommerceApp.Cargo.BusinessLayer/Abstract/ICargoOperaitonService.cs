using EcommerceApp.Cargo.DtoLayer.Dtos.CargoOperationDtos;

namespace EcommerceApp.Cargo.BusinessLayer.Abstract;

public interface ICargoOperaitonService
{
    Task DeleteAsync(int id);
    Task<List<ResultCargoOperationDto>> GetAllAsync();
    Task<GetByIdCargoOperationDto> GetByIdAsync(int id);
    Task CreateAsync(CreateCargoOperationDto createCargoOperationDto);
    Task UpdateAsync(UpdateCargoOperationDto updateCargoOperationDto);
}
