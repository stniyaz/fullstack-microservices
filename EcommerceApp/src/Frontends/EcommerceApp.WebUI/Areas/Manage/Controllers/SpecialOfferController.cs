using EcommerceApp.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;
[Area("manage")]
public class SpecialOfferController(IHttpClientFactory _clientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/specialOffers/");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);

            return View(values);
        }

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateSpecialOfferDto dto)
    {
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7070/api/specialOffers/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "specialoffer", new { area = "manage" });
        }
        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7070/api/specialOffers/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);

            return View(value);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateSpecialOfferDto dto)
    {
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7070/api/specialOffers/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "specialoffer", new { area = "manage" });
        }

        return View();
    }
    public async Task<IActionResult> Delete(string id)
    {
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/specialOffers?id={id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "specialoffer", new { area = "manage" });
        }

        return NotFound();
    }
}
