using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class CategoryController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/categories");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(categoryDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7070/api/categories", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "category", new { area = "manage" });
        }

        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/categories/" + id);

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);

            return View(values);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync("https://localhost:7070/api/categories/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "category", new { area = "manage" });
        }

        return View();
    }
    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:7070/api/categories?categoryId="+id);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "category", new { area = "manage" });
        }

        return NotFound();
    }
}
