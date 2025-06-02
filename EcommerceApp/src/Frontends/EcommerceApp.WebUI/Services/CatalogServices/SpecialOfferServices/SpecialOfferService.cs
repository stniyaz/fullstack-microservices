using EcommerceApp.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CatalogServices.SpecialOfferServices;

public class SpecialOfferService(HttpClient _httpClient) : ISpecialOfferService
{
    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        => await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);

    public async Task DeleteSpecialOfferAsync(string specialOfferId)
        => await _httpClient.DeleteAsync($"specialoffers?id={specialOfferId}");

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
    {
        var responseMessage = await _httpClient.GetAsync("specialoffers");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
        return values;
    }

    public async Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string SpecialOfferId)
    {
        var responseMessage = await _httpClient.GetAsync($"specialoffers/{SpecialOfferId}");
        var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();

        return value;
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateSpecialOfferDto);
    }
}
