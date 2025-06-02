using EcommerceApp.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace EcommerceApp.WebUI.Services.CatalogServices.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string specialOfferId);
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();
    Task DeleteSpecialOfferAsync(string specialOfferId);
}
