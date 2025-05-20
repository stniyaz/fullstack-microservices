using EcommerceApp.Cargo.DtoLayer.Dtos.CargoCustomerDtos;

namespace EcommerceApp.Cargo.BusinessLayer.Abstract;

public interface ICargoCustomerService
{
    Task DeleteAsync(int id);
    Task<List<ResultCargoCustomerDto>> GetAllAsync();
    Task<GetByIdCargoCustomerDto> GetByIdAsync(int id);
    Task CreateAsync(CreateCargoCustomerDto createCargoCustomerDto);
    Task UpdateAsync(UpdateCargoCustomerDto updateCargoCustomerDto);
}
