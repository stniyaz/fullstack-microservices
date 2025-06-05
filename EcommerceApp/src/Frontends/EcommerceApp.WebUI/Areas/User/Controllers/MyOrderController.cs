using EcommerceApp.WebUI.Services.OrderServices.OrderingServices;
using EcommerceApp.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.User.Controllers;

[Area("user")]
public class MyOrderController(IUserService _userService, IOrderingService _orderingService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var userInfo = await _userService.GetUserInfoAsync();

        var values = await _orderingService.GetOrderingsByUserIdAsync(userInfo.Id);

        return View(values);
    }
}
