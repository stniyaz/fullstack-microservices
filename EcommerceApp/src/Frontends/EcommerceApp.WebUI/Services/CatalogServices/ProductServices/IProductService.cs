using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;

namespace EcommerceApp.WebUI.Services.CatalogServices.ProductServices;

public interface IProductService
{
    Task DeleteProductAsync(string productId);
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task<UpdateProductDto> GetProductByIdAsync(string productId);
    Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategory();
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string ctgId);
}
