using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
