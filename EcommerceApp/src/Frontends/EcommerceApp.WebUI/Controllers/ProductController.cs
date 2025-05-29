using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;
using EcommerceApp.DtoLayer.CommentDtos.UserCommentDtos;
using EcommerceApp.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Controllers;

public class ProductController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index(string? ctgId)
    {
        ViewBag.Active = "products";
        var viewModel = new ProductIndexViewModel();

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
        var viewModel = new ProductDetailViewModel();
        var client = _httpClientFactory.CreateClient();
        var productResponse = await client.GetAsync($"https://localhost:7070/api/products/{pdtId}");
        var commentResponse = await client.GetAsync($"https://localhost:7075/api/usercomments/GetCommentsByProductId?id={pdtId}");

        if (productResponse.IsSuccessStatusCode)
        {
            var productJson = await productResponse.Content.ReadAsStringAsync();
            viewModel.Product = JsonConvert.DeserializeObject<ResultProductWithCategoryDto>(productJson);

            if (commentResponse.IsSuccessStatusCode)
            {
                var commentJson = await commentResponse.Content.ReadAsStringAsync();
                viewModel.Comments = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(commentJson);
            }

            return View(viewModel);
        }

        return NotFound();
    }
}
