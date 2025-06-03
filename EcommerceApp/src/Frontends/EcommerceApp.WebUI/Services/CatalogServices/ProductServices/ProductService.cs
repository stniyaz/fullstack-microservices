using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CatalogServices.ProductServices;

public class ProductService(HttpClient _httpClient) : IProductService
{
    public async Task CreateProductAsync(CreateProductDto createProductDto)
        => await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);

    public async Task DeleteProductAsync(string productId)
        => await _httpClient.DeleteAsync($"products?productId={productId}");

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("products");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
        return values;
    }

    public async Task<UpdateProductDto> GetProductByIdAsync(string productId)
    {
        var responseMessage = await _httpClient.GetAsync($"products/{productId}");
        var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();

        return value;
    }

    public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategory()
    {
        var responseMessage = await _httpClient.GetAsync("products/GetAllProductsWithCategory");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);

        return values;
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string ctgId)
    {
        var responseMessage = await _httpClient.GetAsync($"products/GetProductsWithCategoryByCategoryIdAsync?ctgId={ctgId}");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);

        return values;
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        => await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
}