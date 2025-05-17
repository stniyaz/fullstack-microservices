using EcommerceApp.Catalog.Dtos.ProductDetailDtos;
using EcommerceApp.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController(IProductDetailService _productDetailService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllProductDetails()
    {
        var values = await _productDetailService.GetAllProductDetailsAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var value = await _productDetailService.GetByIdProductDetailAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _productDetailService.CreateProductDetailAsync(createProductDetailDto);

        return StatusCode(201, "ProductDetail created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);

        return Ok("ProductDetail updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductDetail(string productDetailId)
    {
        await _productDetailService.DeleteProductDetailAsync(productDetailId);

        return Ok("ProductDetail deleted successfully");
    }
}
