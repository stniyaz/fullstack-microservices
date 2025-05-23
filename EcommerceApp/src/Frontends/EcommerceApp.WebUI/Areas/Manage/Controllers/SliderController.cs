using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;
[Area("manage")]
public class SliderController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/sliders");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);

            return View(values);
        }

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateSliderDto createSliderDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createSliderDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7070/api/sliders", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "slider", new { area = "manage" });
        }
        return View(createSliderDto);
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage =
            await client.GetAsync("https://localhost:7070/api/sliders/" + id);

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);

            return View(value);
        }

        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateSliderDto updateSliderDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateSliderDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7070/api/sliders/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "slider", new { area = "manage" });
        }

        return View(updateSliderDto);
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/sliders?id={id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "slider", new { area = "manage" });
        }

        return NotFound();
    }
}
