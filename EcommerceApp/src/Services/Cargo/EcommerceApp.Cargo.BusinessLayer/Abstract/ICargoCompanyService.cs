using EcommerceApp.Cargo.DtoLayer.Dtos.CargoCompanyDtos;

namespace EcommerceApp.Cargo.BusinessLayer.Abstract;

public interface ICargoCompanyService
{
    Task DeleteAsync(int id);
    Task<List<ResultCargoCompanyDto>> GetAllAsync();
    Task<GetByIdCargoCompanyDto> GetByIdAsync(int id);
    Task CreateAsync(CreateCargoCompanyDto createCargoCompanyDto);
    Task UpdateAsync(UpdateCargoCompanyDto updateCargoCompanyDto);

}
