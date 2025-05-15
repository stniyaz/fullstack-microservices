using EcommerceApp.Catalog.Dtos.CategoryDtos;

namespace EcommerceApp.Catalog.Services.CategoryServices;

public interface ICategoryService
{
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId);
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task DeleteCategoryAsync(string categoryId);
}
