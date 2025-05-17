using EcommerceApp.Catalog.Dtos.ProductImageDtos;
using EcommerceApp.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductImagesController(IProductImageService _productImageService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllProductImages()
    {
        var values = await _productImageService.GetAllProductImagesAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var value = await _productImageService.GetByIdProductImageAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _productImageService.CreateProductImageAsync(createProductImageDto);

        return StatusCode(201, "ProductImage created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _productImageService.UpdateProductImageAsync(updateProductImageDto);

        return Ok("ProductImage updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(string productImageId)
    {
        await _productImageService.DeleteProductImageAsync(productImageId);

        return Ok("ProductImage deleted successfully.");
    }
}
