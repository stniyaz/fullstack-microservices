using AutoMapper;
using EcommerceApp.Catalog.Dtos.ProductImageDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Services.ProductImageServices;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.ProductImageServicesl;

public class ProductImageService : IProductImageService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductImage> _productImagesCollection;

    public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productImagesCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        => await _productImagesCollection.InsertOneAsync(_mapper.Map<ProductImage>(createProductImageDto));

    public async Task DeleteProductImageAsync(string productImageId)
        => await _productImagesCollection.DeleteOneAsync(x => x.ProductImageId == productImageId);

    public async Task<List<ResultProductImageDto>> GetAllCategoriesAsync()
        => _mapper.Map<List<ResultProductImageDto>>(await _productImagesCollection.Find(x => true).ToListAsync());

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productImageId)
        => _mapper.Map<GetByIdProductImageDto>(await _productImagesCollection.Find(x => x.ProductImageId == productImageId).FirstOrDefaultAsync());

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        => await _productImagesCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, _mapper.Map<ProductImage>(updateProductImageDto));
}
