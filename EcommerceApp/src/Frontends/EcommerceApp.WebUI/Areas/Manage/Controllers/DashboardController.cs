using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
