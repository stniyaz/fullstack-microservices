using EcommerceApp.DtoLayer.CatalogDtos.BrandDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class SettingController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/settings/");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultSettingDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/settings/" + id);

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateSettingDto>(jsonData);

            return View(values);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSettingDto updateSettingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateSettingDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync("https://localhost:7070/api/settings/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "setting", new { area = "manage" });
        }

        return View();
    }
}
