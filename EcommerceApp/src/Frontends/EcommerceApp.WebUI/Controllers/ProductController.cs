using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;
using EcommerceApp.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Controllers;

public class ProductController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index(string? ctgId)
    {
        ViewBag.Active = "products";
        var viewModel = new ProductViewModel();

        var client = _httpClientFactory.CreateClient();

        var requestUrl = string.IsNullOrEmpty(ctgId) ? "https://localhost:7070/api/products/" : $"https://localhost:7070/api/products/GetProductsWithCategoryByCategoryId?ctgId={ctgId}";

        var productResponse = await client.GetAsync(requestUrl);

        if (productResponse.IsSuccessStatusCode)
        {
            var jsonData = await productResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            viewModel.Products = products;
        }

        return View(viewModel);
    }

    public async Task<IActionResult> Detail(string pdtId)
    {
        var client = _httpClientFactory.CreateClient();
        var productResponse = await client.GetAsync($"https://localhost:7070/api/products/{pdtId}");

        if (productResponse.IsSuccessStatusCode)
        {
            var jsonData = await productResponse.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
            return View(product);
        }

        return NotFound();
    }
}
