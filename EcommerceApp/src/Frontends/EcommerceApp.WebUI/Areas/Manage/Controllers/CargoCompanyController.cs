using EcommerceApp.DtoLayer.CargoDtos.CargoCompanyDtos;
using EcommerceApp.WebUI.Services.CargoServices.CargoCompanyServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class CargoCompanyController(ICargoCompanyService _cargoCompanyService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _cargoCompanyService.GetAllCargoCompanysAsync();

        return View(values);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCargoCompanyDto dto)
    {
        await _cargoCompanyService.CreateCargoCompanyAsync(dto);

        return RedirectToAction("index", "cargocompany", new { area = "manage" });
    }

    public async Task<IActionResult> Update(int id)
    {
        var value = await _cargoCompanyService.GetCargoCompanyByIdAsync(id);

        if (value is not null)
        {
            return View(value);
        }

        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateCargoCompanyDto dto)
    {
        await _cargoCompanyService.UpdateCargoCompanyAsync(dto);

        return RedirectToAction("index", "cargocompany", new { area = "manage" });
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _cargoCompanyService.DeleteCargoCompanyAsync(id);

        return RedirectToAction("index", "cargocompany", new { area = "manage" });
    }
}
