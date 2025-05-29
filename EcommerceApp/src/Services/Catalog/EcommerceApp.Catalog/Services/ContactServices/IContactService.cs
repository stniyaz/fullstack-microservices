using EcommerceApp.Catalog.Dtos.ContactDtos;

namespace EcommerceApp.Catalog.Services.ContactServices;

public interface IContactService
{
    Task CreateContactAsync(CreateContactDto createContactDto);
    Task<GetByIdContactDto> GetByIdContactAsync(string contactId);
    Task<List<ResultContactDto>> GetAllContactsAsync();
    Task DeleteContactAsync(string contactId);
}
