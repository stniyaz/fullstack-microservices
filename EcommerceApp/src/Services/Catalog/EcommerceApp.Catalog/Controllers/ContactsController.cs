using EcommerceApp.Catalog.Dtos.ContactDtos;
using EcommerceApp.Catalog.Services.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ContactsController(IContactService _contactService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllContacts()
    {
        var values = await _contactService.GetAllContactsAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(string id)
    {
        var value = await _contactService.GetByIdContactAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
        await _contactService.CreateContactAsync(createContactDto);

        return StatusCode(201, "Contact created successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(string id)
    {
        await _contactService.DeleteContactAsync(id);

        return Ok("Contact deleted successfully.");
    }
}
