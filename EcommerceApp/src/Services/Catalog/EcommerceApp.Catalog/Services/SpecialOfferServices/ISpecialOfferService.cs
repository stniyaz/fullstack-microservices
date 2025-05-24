using EcommerceApp.Catalog.Dtos.SpecialOfferDtos;

namespace EcommerceApp.Catalog.Services.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string specialOfferId);
    Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();
    Task DeleteSpecialOfferAsync(string specialOfferId);
}
