using EcommerceApp.Catalog.Dtos.ProductDetailDtos;

namespace EcommerceApp.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId);
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task DeleteProductDetailAsync(string productDetailId);
    }
}
