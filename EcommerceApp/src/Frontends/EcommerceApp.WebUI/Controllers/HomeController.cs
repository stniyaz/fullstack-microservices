using EcommerceApp.DtoLayer.CatalogDtos.FeatureDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SpecialOfferDtos;
using EcommerceApp.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Controllers;

public class HomeController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeViewModel();
        ViewBag.Active = "home";

        var client = _httpClientFactory.CreateClient();

        var sliderResponse = await client.GetAsync("https://localhost:7070/api/sliders/");
        var specialOfferResponse = await client.GetAsync("https://localhost:7070/api/specialoffers/");
        var featureResponse = await client.GetAsync("https://localhost:7070/api/features/");

        if (sliderResponse.IsSuccessStatusCode)
        {
            var jsonData = await sliderResponse.Content.ReadAsStringAsync();
            viewModel.Sliders = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
        }

        if (specialOfferResponse.IsSuccessStatusCode)
        {
            var jsonData = await specialOfferResponse.Content.ReadAsStringAsync();
            viewModel.SpecialOffers = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
        }

        if (featureResponse.IsSuccessStatusCode)
        {
            var jsonData = await featureResponse.Content.ReadAsStringAsync();
            viewModel.Features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
        }

        return View(viewModel);
    }
}
