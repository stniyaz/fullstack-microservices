using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.CatalogServices.CategoryServices;

public class CategoryService(HttpClient _httpClient) : ICategoryService
{
    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        => await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);

    public async Task DeleteCategoryAsync(string categoryId)
        => await _httpClient.DeleteAsync($"categories?categoryId={categoryId}");

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        var responseMessage = await _httpClient.GetAsync("categories");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        return values;
    }

    public async Task<UpdateCategoryDto> GetCategoryByIdAsync(string categoryId)
    {
        var responseMessage = await _httpClient.GetAsync($"categories/{categoryId}");
        var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();

        return value;
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
    }
}
