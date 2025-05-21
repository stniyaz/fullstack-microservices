using EcommerceApp.Basket.Dtos.BasketDtos;
using EcommerceApp.Basket.Services.BasketServices;
using EcommerceApp.Basket.Services.LoginServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController(IBasketService _basketService, ILoginService _loginService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetBasket()
        => Ok(await _basketService.GetBasketAsync(_loginService.GetUserId));

    [HttpPost]
    public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = _loginService.GetUserId;

        await _basketService.SaveBasketAsync(basketTotalDto);

        return Ok("Changes to the cart have been saved.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await _basketService.DeleteBasketAsync(_loginService.GetUserId);

        return Ok("Cart deleted successfully.");
    }
}
