using EcommerceApp.DtoLayer.CatalogDtos.BrandDtos;
using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using EcommerceApp.DtoLayer.CatalogDtos.FeatureDtos;
using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SpecialOfferDtos;
using EcommerceApp.WebUI.Services.BasketServices;
using EcommerceApp.WebUI.Services.CatalogServices.BrandServices;
using EcommerceApp.WebUI.Services.CatalogServices.CategoryServices;
using EcommerceApp.WebUI.Services.CatalogServices.FeatureServices;
using EcommerceApp.WebUI.Services.CatalogServices.ProductServices;
using EcommerceApp.WebUI.Services.CatalogServices.SliderServices;
using EcommerceApp.WebUI.Services.CatalogServices.SpecialOfferServices;
using EcommerceApp.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Controllers;

public class HomeController(IBrandService _brandService,
                            ISliderService _sliderService,
                            IBasketService _basketService,
                            IFeatureService _featureService,
                            IProductService _productService,
                            ICategoryService _categoryService,
                            ISpecialOfferService _specialOfferService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeViewModel();
        ViewBag.Active = "home";

        viewModel.Sliders = await _sliderService.GetAllSlidersAsync();
        viewModel.Brands = await _brandService.GetAllBrandsAsync();
        viewModel.Features = await _featureService.GetAllFeaturesAsync();
        viewModel.Categories = await _categoryService.GetAllCategoriesAsync();
        viewModel.SpecialOffers = await _specialOfferService.GetAllSpecialOffersAsync();
        viewModel.Products = await _productService.GetAllProductsAsync();

        if (HttpContext.User.Identity.IsAuthenticated)
        {
            ViewBag.BasketItemsCount = await _basketService.GetBasketItemCountAsync();
        }

        return View(viewModel);
    }
}
