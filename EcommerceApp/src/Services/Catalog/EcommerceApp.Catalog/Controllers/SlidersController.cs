using EcommerceApp.Catalog.Dtos.SliderDtos;
using EcommerceApp.Catalog.Services.SliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class SlidersController(ISliderService _sliderService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllSliders()
    {
        var values = await _sliderService.GetAllSlidersAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSliderById(string id)
    {
        var value = await _sliderService.GetByIdSliderAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
    {
        await _sliderService.CreateSliderAsync(createSliderDto);

        return StatusCode(201,"Slider created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
    {
        await _sliderService.UpdateSliderAsync(updateSliderDto);

        return Ok("Slider updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSlider(string id)
    {
        await _sliderService.DeleteSliderAsync(id);

        return Ok("Slider deleted successfully.");
    }
}
