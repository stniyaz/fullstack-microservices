using EcommerceApp.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Controllers;

public class DiscountController(IDiscountService _discountService) : Controller
{
    public async Task<IActionResult> ApplyDiscountCode(string code)
    {
        var value = await _discountService.GetDiscountCodeAsync(code);

        return Json(JsonConvert.SerializeObject(value));
    }
}
