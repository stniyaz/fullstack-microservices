using EcommerceApp.Catalog.Services.StatisticServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class StatisticsController(IStatisticService _statisticService) : ControllerBase
{
    [HttpGet("GetBrandCount")]
    public async Task<IActionResult> GetBrandCount()
    {
        var value = await _statisticService.GetBrandCountAsync();

        return Ok(value);
    }

    [HttpGet("GetProductCount")]
    public async Task<IActionResult> GetProductCount()
    {
        var value = await _statisticService.GetProductCountAsync();

        return Ok(value);
    }

    [HttpGet("GetCategoryCount")]
    public async Task<IActionResult> GetCategoryCount()
    {
        var value = await _statisticService.GetCategoryCountAsync();

        return Ok(value);
    }

    [HttpGet("GetProductsAvgPrice")]
    public async Task<IActionResult> GetProductsAvgPrice()
    {
        var value = await _statisticService.GetProductAvgPriceAsync();

        return Ok(value);
    }

    [HttpGet("GetMaxPriceProductName")]
    public async Task<IActionResult> GetMaxPriceProductName()
    {
        var value = await _statisticService.GetMaxPriceProductNameAsync();

        return Ok(value);
    }

    [HttpGet("GetMinPriceProductName")]
    public async Task<IActionResult> GetMinPriceProductName()
    {
        var value = await _statisticService.GetMinPriceProductNameAsync();

        return Ok(value);
    }
}
