using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;
[Area("manage")]
public class ProductController(IHttpClientFactory _clientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/products");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

            return View(values);
        }

        return View();
    }

    public async Task<IActionResult> Create()
    {
        // get categories
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/categories");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            ViewBag.Categories = values;
        }

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        // get categories
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/categories");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            ViewBag.Categories = values;
        }

        // create product
        var client2 = _clientFactory.CreateClient();
        var jsonData2 = JsonConvert.SerializeObject(dto);
        var content = new StringContent(jsonData2, Encoding.UTF8, "application/json");
        var responseMessage2 = await client2.PostAsync("https://localhost:7070/api/products", content);

        if (responseMessage2.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "product", new { area = "manage" });
        }

        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        // get categories
        var client1 = _clientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:7070/api/categories");

        if (responseMessage1.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage1.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            ViewBag.Categories = values;
        }

        // get product
        var client2 = _clientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("https://localhost:7070/api/products/" + id);

        if (responseMessage2.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

            return View(values);
        }

        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        // get categories
        var client1 = _clientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:7070/api/categories");

        if (responseMessage1.IsSuccessStatusCode)
        {
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);

            ViewBag.Categories = values;
        }

        // update product
        var client2 = _clientFactory.CreateClient();
        var jsonData2 = JsonConvert.SerializeObject(dto);
        var content = new StringContent(jsonData2, Encoding.UTF8, "application/json");
        var responseMessage = await client2.PutAsync("https://localhost:7070/api/products/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "product", new { area = "manage" });
        }

        return View(dto);
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _clientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/products?productId=" + id);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "product", new { area = "manage" });
        }

        return NotFound();
    }
}
