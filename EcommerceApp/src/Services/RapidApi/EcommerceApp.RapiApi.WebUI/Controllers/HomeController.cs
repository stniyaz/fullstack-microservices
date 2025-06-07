using EcommerceApp.RapiApi.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceApp.RapiApi.WebUI.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> WeatherDetail()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://weather-api138.p.rapidapi.com/weather?city_name=Baku"),
            Headers =
            {
                 { "x-rapidapi-key", "c0448c6effmsh29b21a7ad163523p1020cajsn784d36be803e" },
                 { "x-rapidapi-host", "weather-api138.p.rapidapi.com" },
            },
        };

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);

            double kelvin = values.main.temp;

            double celsius = kelvin - 273.15;

            ViewBag.Temperature = celsius;

        }
        return View();
    }

    public async Task<IActionResult> Exchange()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-converter-pro1.p.rapidapi.com/latest-rates?base=USD&currencies=AZN"),
            Headers =
    {
        { "x-rapidapi-key", "c0448c6effmsh29b21a7ad163523p1020cajsn784d36be803e" },
        { "x-rapidapi-host", "currency-converter-pro1.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);

            float azn = value.result.AZN;

            ViewBag.Currency = azn;
        }

        return View();
    }
}
