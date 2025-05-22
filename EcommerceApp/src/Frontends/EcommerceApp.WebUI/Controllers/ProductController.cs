using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Active = "products";

        return View();
    }

    public IActionResult Detail()
    {
        return View();
    }
}
