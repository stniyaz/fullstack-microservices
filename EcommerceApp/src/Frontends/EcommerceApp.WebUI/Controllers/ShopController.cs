using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class ShopController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
