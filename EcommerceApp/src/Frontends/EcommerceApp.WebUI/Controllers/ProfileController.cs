using EcommerceApp.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class ProfileController(IUserService _userService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _userService.GetUserInfoAsync();

        return View(values);
    }
}
