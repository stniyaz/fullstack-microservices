using EcommerceApp.DtoLayer.CatalogDtos.ContactDtos;
using EcommerceApp.WebUI.Services.CatalogServices.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class ContactController(IContactService _contactService) : Controller
{
    public IActionResult Index()
    {
        ViewBag.Active = "contact";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto dto)
    {
        await _contactService.CreateContactAsync(dto);

        return RedirectToAction("index", "contact");
    }
}