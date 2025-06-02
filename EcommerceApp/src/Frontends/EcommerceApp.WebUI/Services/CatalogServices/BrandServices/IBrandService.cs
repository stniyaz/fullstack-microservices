using EcommerceApp.DtoLayer.CatalogDtos.BrandDtos;

namespace EcommerceApp.WebUI.Services.CatalogServices.BrandServices;

public interface IBrandService
{
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    Task<UpdateBrandDto> GetBrandByIdAsync(string brandId);
    Task<List<ResultBrandDto>> GetAllBrandsAsync();
    Task DeleteBrandAsync(string brandId);
}
