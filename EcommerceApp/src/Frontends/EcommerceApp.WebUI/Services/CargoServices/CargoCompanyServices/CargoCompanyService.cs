using EcommerceApp.DtoLayer.CargoDtos.CargoCompanyDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CargoServices.CargoCompanyServices;

public class CargoCompanyService(HttpClient _httpClient) : ICargoCompanyService
{
    public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto dto)
        => await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargocompanies", dto);

    public async Task DeleteCargoCompanyAsync(int id)
        => await _httpClient.DeleteAsync($"cargocompanies?id={id}");

    public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanysAsync()
    {
        var responseMessage = await _httpClient.GetAsync("cargocompanies");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();

        return values;
    }

    public async Task<UpdateCargoCompanyDto> GetCargoCompanyByIdAsync(int id)
    {
        var responseMessage = await _httpClient.GetAsync($"cargocompanies/{id}");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<UpdateCargoCompanyDto>(jsonData);

        return value;
    }

    public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargocompanies", dto);

        var asd = "Asd";
    }
}
