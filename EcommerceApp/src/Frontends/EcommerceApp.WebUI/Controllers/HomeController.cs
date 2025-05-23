using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Controllers;

public class HomeController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Active = "home";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/sliders/");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var sliders = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);

            return View(sliders);
        }

        return View();
    }
}
