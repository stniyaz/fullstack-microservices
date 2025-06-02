using EcommerceApp.DtoLayer.CatalogDtos.BrandDtos;
using EcommerceApp.WebUI.Services.CatalogServices.BrandServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class BrandController(IBrandService _brandService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _brandService.GetAllBrandsAsync();

        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandDto brandDto)
    {
        await _brandService.CreateBrandAsync(brandDto);

        return RedirectToAction("index", "brand", new { area = "manage" });
    }

    public async Task<IActionResult> Update(string id)
    {
        var value = await _brandService.GetBrandByIdAsync(id);

        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateBrandDto updateBrandDto)
    {
        await _brandService.UpdateBrandAsync(updateBrandDto);

        return RedirectToAction("index", "brand", new { area = "manage" });
    }
    public async Task<IActionResult> Delete(string id)
    {
        await _brandService.DeleteBrandAsync(id);

        return RedirectToAction("index", "brand", new { area = "manage" });
    }
}
