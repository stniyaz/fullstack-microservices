using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using EcommerceApp.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace EcommerceApp.WebUI.Controllers
{
    public class TestController(IHttpClientFactory _httpClientFactory, ICategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var token = "";
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        { "client_id", "EcommerceAppVisitorId" },
                        {"client_secret","ecommerceSecret" },
                        {"grant_type","client_credentials" }
                    })
                };

                using (var response = await client.SendAsync(request))
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JObject.Parse(content);

                    token = tokenResponse["access_token"].ToString();
                }
            }

            var clnt = _httpClientFactory.CreateClient();
            clnt.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await clnt.GetAsync("https://localhost:7070/api/categories/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData);

                return Json(jsonData);
            }

            return Ok();
        }

        public async Task<IActionResult> TestPage()
        {
            var values = await _categoryService.GetAllCategoriesAsync();

            return Json(JsonConvert.SerializeObject(values));
        }
    }
}
