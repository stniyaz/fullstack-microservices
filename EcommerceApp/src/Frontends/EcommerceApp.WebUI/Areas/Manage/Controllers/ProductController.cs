using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;
using EcommerceApp.WebUI.Services.CatalogServices.CategoryServices;
using EcommerceApp.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;
[Area("manage")]
public class ProductController(IProductService _productService,
                               ICategoryService _categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _productService.GetAllProductsWithCategory();

        return View(values);
    }

    public async Task<IActionResult> Create()
    {
        // get categories
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.Categories = categories;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        // get categories
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.Categories = categories;

        // create product
        await _productService.CreateProductAsync(dto);

        return RedirectToAction("index", "product", new { area = "manage" });
    }

    public async Task<IActionResult> Update(string id)
    {
        // get categories
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.Categories = categories;

        // get product
        var existProduct = await _productService.GetProductByIdAsync(id);

        return View(existProduct);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductDto dto)
    {
        // get categories
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.Categories = categories;

        // update product
        await _productService.UpdateProductAsync(dto);

        return RedirectToAction("index", "product", new { area = "manage" });
    }

    public async Task<IActionResult> Delete(string id)
    {
        await _productService.DeleteProductAsync(id);

        return RedirectToAction("index", "product", new { area = "manage" });
    }
}
