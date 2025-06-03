using EcommerceApp.DtoLayer.BasketDtos;
using EcommerceApp.WebUI.Services.BasketServices;
using EcommerceApp.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class CartController(IBasketService _basketService,
                            IProductService _productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _basketService.GetBasketAsync();
        return View(values);
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
