using EcommerceApp.Catalog.Dtos.ProductImageDtos;

namespace EcommerceApp.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productImageId);
    Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
    Task DeleteProductImageAsync(string productImageId);
}
