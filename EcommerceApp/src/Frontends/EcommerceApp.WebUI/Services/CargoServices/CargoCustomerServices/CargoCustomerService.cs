using EcommerceApp.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace EcommerceApp.WebUI.Services.CargoServices.CargoCustomerServices;

public class CargoCustomerService(HttpClient _httpClient) : ICargoCustomerService
{
    public async Task<ResultCargoCustomerDto> GetCargoCustomerByUserIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"cargocustomers/getcargocustomerbyuserid?id={id}");
        var value = await responseMessage.Content.ReadFromJsonAsync<ResultCargoCustomerDto>();

        return value;
    }
}
