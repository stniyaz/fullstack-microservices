using EcommerceApp.DtoLayer.CatalogDtos.SliderDtos;
using EcommerceApp.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace EcommerceApp.WebUI.ViewModels;

public class HomeViewModel
{
    public List<ResultSliderDto> Sliders { get; set; }
    public List<ResultSpecialOfferDto> SpecialOffers { get; set; }
}
