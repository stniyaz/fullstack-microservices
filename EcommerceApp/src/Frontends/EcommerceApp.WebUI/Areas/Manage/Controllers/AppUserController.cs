using EcommerceApp.WebUI.Services.CargoServices.CargoCustomerServices;
using EcommerceApp.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;
[Area("manage")]
public class AppUserController(IUserService _userService,
                               ICargoCustomerService _cargoCustomerService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var userInfo = await _userService.GetUserInfoAsync();
        var values = await _userService.GetAllUsersAsync(userInfo.Id);

        return View(values);
    }

    public async Task<IActionResult> Address(string id)
    {
        var value = await _cargoCustomerService.GetCargoCustomerByUserIdAsync(id);

        return View(value);
    }
}
