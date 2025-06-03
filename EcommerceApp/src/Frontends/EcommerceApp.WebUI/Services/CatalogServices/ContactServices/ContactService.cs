using EcommerceApp.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CatalogServices.ContactServices;

public class ContactService(HttpClient _httpClient) : IContactService
{
    public async Task CreateContactAsync(CreateContactDto dto)
        => await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", dto);

    public async Task DeleteContactAsync(string id)
        => await _httpClient.DeleteAsync($"contacts?id={id}");

    public async Task<List<ResultContactDto>> GetAllContactsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("contacts");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

        return values;
    }

    public async Task<GetByIdContactDto> GetContactByIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"contacts/{id}");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<GetByIdContactDto>(jsonData);

        return value;
    }
}
