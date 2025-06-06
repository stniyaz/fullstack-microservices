using EcommerceApp.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace EcommerceApp.WebUI.Services.CargoServices.CargoCustomerServices;

public interface ICargoCustomerService
{
    Task<ResultCargoCustomerDto> GetCargoCustomerByUserIdAsync(string id);
}
