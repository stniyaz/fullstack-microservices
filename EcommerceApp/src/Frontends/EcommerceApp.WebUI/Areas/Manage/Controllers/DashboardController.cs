using EcommerceApp.WebUI.Areas.Manage.ViewModels;
using EcommerceApp.WebUI.Services.StatisticServices.CatalogStatisticServices;
using EcommerceApp.WebUI.Services.StatisticServices.CommentStatisticServices;
using EcommerceApp.WebUI.Services.StatisticServices.DiscountStatisticServices;
using EcommerceApp.WebUI.Services.StatisticServices.MessageStatisticServices;
using EcommerceApp.WebUI.Services.StatisticServices.UserStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class DashboardController(ICatalogStatisticService _catalogStatisticService,
                                 ICommentStatisticService _commentStatisticService,
                                 IDiscountStatisticService _discountStatisticService,
                                 IMessageStatisticService _messageStatisticService,
                                 IUserStatisticService _userStatisticService) : Controller
{
    public async Task<IActionResult> Index()
    {
        DashboardViewModel viewModel = new DashboardViewModel();

        viewModel.CategoryCount = await _catalogStatisticService.GetCategoryCountAsync();
        viewModel.ProductCount = await _catalogStatisticService.GetProductCountAsync();
        viewModel.BrandCount = await _catalogStatisticService.GetBrandCountAsync();
        viewModel.ProductAvgPrice = await _catalogStatisticService.GetProductAvgPriceAsync();
        viewModel.MaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductNameAsync();
        viewModel.MinPriceProductName = await _catalogStatisticService.GetMinPriceProductNameAsync();

        viewModel.ActiveUserCommentCount = await _commentStatisticService.GetActiveUserCommentCountAsync();
        viewModel.PassiveUserCommentCount = await _commentStatisticService.GetPassiveUserCommentCountAsync();
        viewModel.TotalUserCommentCount = await _commentStatisticService.GetTotalUserCommentCountAsync();

        viewModel.CouponCount = await _discountStatisticService.GetCouponCountAsync();

        viewModel.TotalUserMessageCount = await _messageStatisticService.GetTotalUserMessageCountAsync();

        viewModel.UserCount = await _userStatisticService.GetUserCountAsync();

        return View(viewModel);
    }
}
