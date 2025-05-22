using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
