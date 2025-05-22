using EcommerceApp.Catalog.Dtos.CategoryDtos;
using EcommerceApp.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
[AllowAnonymous]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCategories()
    {
        var values = await _categoryService.GetAllCategoriesAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var value = await _categoryService.GetByIdCategoryAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await _categoryService.CreateCategoryAsync(createCategoryDto);

        return StatusCode(201, "Catagory created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await _categoryService.UpdateCategoryAsync(updateCategoryDto);

        return Ok("Category updated Sucessfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(string categoryId)
    {
        await _categoryService.DeleteCategoryAsync(categoryId);

        return Ok("Category deleted successfully.");
    }
}
