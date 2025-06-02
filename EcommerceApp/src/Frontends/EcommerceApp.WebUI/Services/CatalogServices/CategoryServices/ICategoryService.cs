using EcommerceApp.DtoLayer.CatalogDtos.CategoryDtos;

namespace EcommerceApp.WebUI.Services.CatalogServices.CategoryServices;

public interface ICategoryService
{
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId);
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task DeleteCategoryAsync(string categoryId);
}
