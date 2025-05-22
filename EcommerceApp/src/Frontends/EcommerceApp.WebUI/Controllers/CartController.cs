using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
