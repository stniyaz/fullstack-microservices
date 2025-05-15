using AutoMapper;
using EcommerceApp.Catalog.Dtos.CategoryDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Category> _categoriesCollection;

    public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoriesCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        => await _categoriesCollection.InsertOneAsync(_mapper.Map<Category>(createCategoryDto));

    public async Task DeleteCategoryAsync(string categoryId)
        => await _categoriesCollection.DeleteOneAsync(x => x.CategoryId == categoryId);

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        => _mapper.Map<List<ResultCategoryDto>>(await _categoriesCollection.Find(x => true).ToListAsync());
    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId)
        => _mapper.Map<GetByIdCategoryDto>(await _categoriesCollection.Find(x => x.CategoryId == categoryId)
                                                                      .FirstOrDefaultAsync());
    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        => await _categoriesCollection.ReplaceOneAsync(x => x.CategoryId == updateCategoryDto.CategoryId,
                                                           _mapper.Map<Category>(updateCategoryDto));
}
