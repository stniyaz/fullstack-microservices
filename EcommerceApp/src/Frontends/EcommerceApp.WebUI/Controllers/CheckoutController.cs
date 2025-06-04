using EcommerceApp.DtoLayer.OrderDtos.OrderAddressDtos;
using EcommerceApp.WebUI.Services.BasketServices;
using EcommerceApp.WebUI.Services.OrderServices.OrderAddressServices;
using EcommerceApp.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class CheckoutController(IUserService _userService,
                                IBasketService _basketService,
                                IOrderAddressService _orderAddressService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var basketTotalDto = await _basketService.GetBasketAsync();
        ViewBag.BasketTotalDto = basketTotalDto;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateOrderAddressDto dto)
    {
        var userInfo = await _userService.GetUserInfoAsync();
        dto.UserId = userInfo.Id;

        await _orderAddressService.CreateAddressOrderAsync(dto);

        //return RedirectToAction("index", "payment");
        return View();
    }
}
