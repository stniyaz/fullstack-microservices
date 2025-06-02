using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using EcommerceApp.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class CategoryController(IHttpClientFactory _httpClientFactory,
                                ICategoryService _categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _categoryService.GetAllCategoriesAsync();

        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
    {
        await _categoryService.CreateCategoryAsync(categoryDto);

        return RedirectToAction("index", "category", new { area = "manage" });
    }

    public async Task<IActionResult> Update(string id)
    {
        var value = await _categoryService.GetByIdCategoryAsync(id);

        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
    {
        await _categoryService.UpdateCategoryAsync(updateCategoryDto);

        return RedirectToAction("index", "category", new { area = "manage" });
    }
    public async Task<IActionResult> Delete(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return RedirectToAction("index", "category", new { area = "manage" });
    }
}
