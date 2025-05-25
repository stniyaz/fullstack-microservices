using EcommerceApp.Catalog.Dtos.FeatureDtos;
using EcommerceApp.Catalog.Services.FeatureServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class FeaturesController(IFeatureService _featureService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCategories()
    {
        var values = await _featureService.GetAllFeaturesAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeatureById(string id)
    {
        var value = await _featureService.GetByIdFeatureAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        await _featureService.CreateFeatureAsync(createFeatureDto);

        return StatusCode(201, "Feature created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        await _featureService.UpdateFeatureAsync(updateFeatureDto);

        return Ok("Feature updated Sucessfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _featureService.DeleteFeatureAsync(id);

        return Ok("Feature deleted successfully.");
    }
}
