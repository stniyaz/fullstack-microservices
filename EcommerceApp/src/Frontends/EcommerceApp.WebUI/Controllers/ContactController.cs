using EcommerceApp.DtoLayer.CatalogDtos.ContactDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EcommerceApp.WebUI.Controllers;

public class ContactController(IHttpClientFactory _httpClientFactory) : Controller
{
    public IActionResult Index()
    {
        ViewBag.Active = "contact";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7070/api/contacts/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "contact");
        }

        return View(dto);
    }
}
