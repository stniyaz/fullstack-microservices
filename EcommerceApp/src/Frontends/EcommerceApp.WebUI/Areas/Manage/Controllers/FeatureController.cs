using EcommerceApp.DtoLayer.CatalogDtos.FeatureDtos;
using EcommerceApp.WebUI.Services.CatalogServices.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class FeatureController(IFeatureService _featureService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _featureService.GetAllFeaturesAsync();

        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDto featureDto)
    {
        await _featureService.CreateFeatureAsync(featureDto);

        return RedirectToAction("index", "feature", new { area = "manage" });
    }

    public async Task<IActionResult> Update(string id)
    {
        var value = await _featureService.GetFeatureByIdAsync(id);

        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateFeatureDto updatefeatureDto)
    {
        await _featureService.UpdateFeatureAsync(updatefeatureDto);

        return RedirectToAction("index", "feature", new { area = "manage" });
    }
    public async Task<IActionResult> Delete(string id)
    {
        await _featureService.DeleteFeatureAsync(id);

        return RedirectToAction("index", "feature", new { area = "manage" });
    }
}
