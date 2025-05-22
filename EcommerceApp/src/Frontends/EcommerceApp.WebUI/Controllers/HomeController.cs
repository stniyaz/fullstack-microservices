using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcommerceApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
