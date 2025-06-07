using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class InformationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
