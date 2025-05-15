using Ecommerce.Discount.Dtos.CouponDtos;
using Ecommerce.Discount.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Discount.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponsController(ICouponService _couponService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCoupons()
    {
        var values = await _couponService.GetAllCouponsAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCouponById(int id)
    {
        var value = await _couponService.GetByIdCouponAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
    {
        await _couponService.CreateCouponAsync(createCouponDto);

        return StatusCode(201, "Coupon created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
    {
        await _couponService.UpdateCouponAsync(updateCouponDto);

        return Ok("Coupon updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        await _couponService.DeleteCouponAsync(id);

        return Ok("Coupon deleted successfully.");
    }
}
