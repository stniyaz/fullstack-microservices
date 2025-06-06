using EcommerceApp.WebUI.Services.StatisticServices.CatalogStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class DashboardController(ICatalogStatisticService _catalogStatisticService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
