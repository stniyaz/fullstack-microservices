using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using EcommerceApp.WebUI.Services.CatalogServices.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;
[Area("manage")]
public class SliderController(ISliderService _sliderService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _sliderService.GetAllSlidersAsync();

        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSliderDto sliderDto)
    {
        await _sliderService.CreateSliderAsync(sliderDto);

        return RedirectToAction("index", "slider", new { area = "manage" });
    }

    public async Task<IActionResult> Update(string id)
    {
        var value = await _sliderService.GetSliderByIdAsync(id);

        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSliderDto updatesliderDto)
    {
        await _sliderService.UpdateSliderAsync(updatesliderDto);

        return RedirectToAction("index", "slider", new { area = "manage" });
    }
    public async Task<IActionResult> Delete(string id)
    {
        await _sliderService.DeleteSliderAsync(id);

        return RedirectToAction("index", "slider", new { area = "manage" });
    }
}
