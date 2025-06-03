using EcommerceApp.DtoLayer.CatalogDtos.ContactDtos;

namespace EcommerceApp.WebUI.Services.CatalogServices.ContactServices;

public interface IContactService
{
    Task DeleteContactAsync(string id);
    Task CreateContactAsync(CreateContactDto dto);
    Task<List<ResultContactDto>> GetAllContactsAsync();
    Task<GetByIdContactDto> GetContactByIdAsync(string id);
}
