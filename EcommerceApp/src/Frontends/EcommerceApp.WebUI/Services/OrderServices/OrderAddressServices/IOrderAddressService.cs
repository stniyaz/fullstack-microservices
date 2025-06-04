using EcommerceApp.DtoLayer.OrderDtos.OrderAddressDtos;

namespace EcommerceApp.WebUI.Services.OrderServices.OrderAddressServices;

public interface IOrderAddressService
{
    Task CreateAddressOrderAsync(CreateOrderAddressDto createOrderAddressDto);
}
