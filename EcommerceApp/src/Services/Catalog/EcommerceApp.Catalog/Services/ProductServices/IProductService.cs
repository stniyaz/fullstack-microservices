using EcommerceApp.Catalog.Dtos.ProductDtos;

namespace EcommerceApp.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
    Task<GetByIdProductDto> GetByIdProductAsync(string productId);
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task DeleteProductAsync(string productId);

}
