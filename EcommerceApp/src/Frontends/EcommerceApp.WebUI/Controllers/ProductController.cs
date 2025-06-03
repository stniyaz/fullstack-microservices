using EcommerceApp.DtoLayer.CommentDtos.UserCommentDtos;
using EcommerceApp.WebUI.Services.CatalogServices.ProductServices;
using EcommerceApp.WebUI.Services.CommentServices.UserCommentServices;
using EcommerceApp.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Controllers;

public class ProductController(IProductService _productService,
                               IUserCommentService _userCommentService) : Controller
{
    public async Task<IActionResult> Index(string? ctgId)
    {
        ViewBag.Active = "products";
        var viewModel = new ProductIndexViewModel();

        viewModel.Products = string.IsNullOrEmpty(ctgId)
                           ? await _productService.GetAllProductsWithCategory()
                           : await _productService.GetProductsWithCategoryByCategoryIdAsync(ctgId);

        var a = 3;


        return View(viewModel);
    }

    public async Task<IActionResult> Detail(string pdtId)
    {
        var viewModel = new ProductDetailViewModel();
        viewModel.Product = await _productService.GetProductByIdAsync(pdtId);
        viewModel.Comments = await _userCommentService.GetAllCommentsByProductIdAsync(pdtId);

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Detail(CreateUserCommentDto dto)
    {
        await _userCommentService.CreateUserCommentAsync(dto);

        return RedirectToAction("detail", "product", new { pdtId = dto.ProductId });
    }
}
