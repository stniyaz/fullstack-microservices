using EcommerceApp.Catalog.Dtos.BrandDtos;
using EcommerceApp.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class BrandsController(IBrandService _brandService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllBrands()
    {
        var values = await _brandService.GetAllBrandsAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(string id)
    {
        var value = await _brandService.GetByIdBrandAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        await _brandService.CreateBrandAsync(createBrandDto);

        return StatusCode(201, "Brand created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        await _brandService.UpdateBrandAsync(updateBrandDto);

        return Ok("Brand updated Sucessfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrandAsync(id);

        return Ok("Brand deleted successfully.");
    }
}
