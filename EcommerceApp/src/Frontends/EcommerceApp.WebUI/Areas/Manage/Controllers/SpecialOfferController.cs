using EcommerceApp.DtoLayer.CatalogDtos.SpecialOfferDtos;
using EcommerceApp.WebUI.Services.CatalogServices.SpecialOfferServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;
[Area("manage")]
public class SpecialOfferController(ISpecialOfferService _specialOfferService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _specialOfferService.GetAllSpecialOffersAsync();

        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSpecialOfferDto specialOfferDto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(specialOfferDto);

        return RedirectToAction("index", "specialOffer", new { area = "manage" });
    }

    public async Task<IActionResult> Update(string id)
    {
        var value = await _specialOfferService.GetSpecialOfferByIdAsync(id);

        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSpecialOfferDto updatespecialOfferDto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(updatespecialOfferDto);

        return RedirectToAction("index", "specialOffer", new { area = "manage" });
    }
    public async Task<IActionResult> Delete(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);

        return RedirectToAction("index", "specialOffer", new { area = "manage" });
    }
}
