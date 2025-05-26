using EcommerceApp.DtoLayer.CatalogDtos.BrandDtos;
using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using EcommerceApp.DtoLayer.CatalogDtos.FeatureDtos;
using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SettingDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace EcommerceApp.WebUI.ViewModels;

public class HomeViewModel
{
    public List<ResultBrandDto> Brands { get; set; }
    public List<ResultSliderDto> Sliders { get; set; }
    public List<ResultFeatureDto> Features { get; set; }
    public List<ResultProductDto> Products { get; set; }
    public List<ResultCategoryDto> Categories { get; set; }
    public List<ResultSpecialOfferDto> SpecialOffers { get; set; }
}
