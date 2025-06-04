using EcommerceApp.DtoLayer.OrderDtos.OrderAddressDtos;

namespace EcommerceApp.WebUI.Services.OrderServices.OrderAddressServices;

public class OrderAddressService(HttpClient _httpClient) : IOrderAddressService
{
    public async Task CreateAddressOrderAsync(CreateOrderAddressDto createOrderAddressDto)
        => await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
}
