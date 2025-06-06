using EcommerceApp.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace EcommerceApp.WebUI.Services.CargoServices.CargoCompanyServices;

public interface ICargoCompanyService
{
    Task DeleteCargoCompanyAsync(int id);
    Task<UpdateCargoCompanyDto> GetCargoCompanyByIdAsync(int id);
    Task<List<ResultCargoCompanyDto>> GetAllCargoCompanysAsync();
    Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto dto);
    Task CreateCargoCompanyAsync(CreateCargoCompanyDto dto);
}
