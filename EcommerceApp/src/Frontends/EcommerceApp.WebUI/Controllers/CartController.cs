using EcommerceApp.DtoLayer.BasketDtos;
using EcommerceApp.WebUI.Services.BasketServices;
using EcommerceApp.WebUI.Services.CatalogServices.ProductServices;
using EcommerceApp.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EcommerceApp.WebUI.Controllers;

public class CartController(IBasketService _basketService,
                            IDiscountService _discountService,
                            IProductService _productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var basketTotalDto = await _basketService.GetBasketAsync();
        ViewBag.TotalPriceWithTaxAndDiscount = basketTotalDto.TotalPrice + (basketTotalDto.TotalPrice * 0.1m);
        return View(basketTotalDto);
    }

    [HttpPost]
    public async Task<IActionResult> Index(string code)
    {
        var basketTotalDto = await _basketService.GetBasketAsync();
        var coupon = await _discountService.GetCouponByCodeAsync(code);

        if (coupon != null)
        {
            decimal totalPriceWithTax = basketTotalDto.TotalPrice + (basketTotalDto.TotalPrice * 10) / 100;
            decimal totalPriceWithTaxAndDiscount
                = totalPriceWithTax - (totalPriceWithTax * coupon.Rate / 100);

            ViewBag.TotalPriceWithTaxAndDiscount = totalPriceWithTaxAndDiscount;

            basketTotalDto.DiscountRate = coupon.Rate;
            basketTotalDto.DiscountCode = coupon.Code;

            return View(basketTotalDto);
        }

        return RedirectToAction("index", basketTotalDto);
    }

    public async Task<IActionResult> AddBasketItem(string productId)
    {
        var product = await _productService.GetProductByIdAsync(productId);
        var items = new BasketItemDto()
        {
            ProductId = productId,
            Name = product.ProductName,
            Price = product.ProductPrice,
            ImageUrl = product.ProductImageUrl,
            Quantity = 1
        };
        await _basketService.AddBasketItemAsync(items);

        return RedirectToAction("index");
    }

    public async Task<IActionResult> RemoveBasketItem(string productId)
    {
        await _basketService.RemoveBasketItem(productId);

        return RedirectToAction("index");
    }
}
