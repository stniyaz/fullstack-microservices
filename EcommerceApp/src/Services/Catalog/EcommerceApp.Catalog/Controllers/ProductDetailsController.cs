using EcommerceApp.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController(IProductDetailService _productDetailService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllProductDetails()
    {
        var values = await _productDetailService.GetAllProductDetaisAsync();

        return Ok(values);
    }
}
