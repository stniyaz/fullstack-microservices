using EcommerceApp.Catalog.Dtos.ProductDtos;
using EcommerceApp.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService _productService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllProducts()
    {
        var values = await _productService.GetAllProductsAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var value = await _productService.GetByIdProductAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        await _productService.CreateProductAsync(createProductDto);

        return StatusCode(201, "Product created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await _productService.UpdateProductAsync(updateProductDto);

        return Ok("Product updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(string productId)
    {
        await _productService.DeleteProductAsync(productId);

        return Ok("Product deleted successfully.");
    }
}
