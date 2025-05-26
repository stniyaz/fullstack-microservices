using EcommerceApp.Catalog.Dtos.BrandDtos;

namespace EcommerceApp.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task DeleteBrandAsync(string id);
    Task CreateBrandAsync(CreateBrandDto dto);
    Task UpdateBrandAsync(UpdateBrandDto dto);
    Task<List<ResultBrandDto>> GetAllBrandsAsync();
    Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
}
