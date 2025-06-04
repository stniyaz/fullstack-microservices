using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class PaymentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
