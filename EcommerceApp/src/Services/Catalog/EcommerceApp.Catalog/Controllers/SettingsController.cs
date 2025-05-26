using EcommerceApp.Catalog.Dtos.SettingDtos;
using EcommerceApp.Catalog.Services.SettingServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class SettingsController(ISettingService _settingService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllSettings()
    {
        var values = await _settingService.GetAllSettingsAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSettingById(string id)
    {
        var value = await _settingService.GetByIdSettingAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSetting(CreateSettingDto createSettingDto)
    {
        await _settingService.CreateSettingAsync(createSettingDto);

        return StatusCode(201, "Setting created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSetting(UpdateSettingDto updateSettingDto)
    {
        await _settingService.UpdateSettingAsync(updateSettingDto);

        return Ok("Setting updated Sucessfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSetting(string id)
    {
        await _settingService.DeleteSettingAsync(id);

        return Ok("Setting deleted successfully.");
    }
}
