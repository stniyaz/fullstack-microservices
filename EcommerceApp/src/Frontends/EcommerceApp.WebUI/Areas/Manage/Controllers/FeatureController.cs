using EcommerceApp.DtoLayer.CatalogDtos.FeatureDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class FeatureController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/features");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

            return View(values);
        }

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFeatureDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7070/api/features", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "feature", new { area = "manage" });
        }
        return View(createFeatureDto);
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage =
            await client.GetAsync("https://localhost:7070/api/features/" + id);

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);

            return View(value);
        }

        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7070/api/features/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "feature", new { area = "manage" });
        }

        return View(updateFeatureDto);
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/features?id={id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "feature", new { area = "manage" });
        }

        return NotFound();
    }
}
