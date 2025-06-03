using EcommerceApp.WebUI.Services.CatalogServices.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class ContactController(IContactService _contactService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _contactService.GetAllContactsAsync();

        return View(values);
    }

    public async Task<IActionResult> Detail(string id)
    {
        var value = await _contactService.GetContactByIdAsync(id);

        return View(value);
    }

    public async Task<IActionResult> Delete(string id)
    {
        await _contactService.DeleteContactAsync(id);

        return RedirectToAction("index", "contact", new { area = "manage" });
    }
}
