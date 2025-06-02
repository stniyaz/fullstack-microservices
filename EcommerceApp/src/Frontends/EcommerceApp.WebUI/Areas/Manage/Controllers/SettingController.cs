using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;
using EcommerceApp.WebUI.Services.CatalogServices.SettingServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class SettingController(ISettingService _settingService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _settingService.GetAllSettingsAsync();

        return View(values);
    }

    public async Task<IActionResult> Update(string id)
    {
        var value = await _settingService.GetSettingByIdAsync(id);

        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSettingDto updateSettingDto)
    {
        await _settingService.UpdateSettingAsync(updateSettingDto);

        return RedirectToAction("index", "setting", new { area = "manage" });
    }
}
