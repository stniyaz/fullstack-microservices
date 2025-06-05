using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.User.Controllers
{
    [Area("user")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
