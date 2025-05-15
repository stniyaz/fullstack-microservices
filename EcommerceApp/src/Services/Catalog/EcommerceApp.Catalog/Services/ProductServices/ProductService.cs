using AutoMapper;
using EcommerceApp.Catalog.Dtos.ProductDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productsCollection;

    public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productsCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);

    }
    public async Task CreateProductAsync(CreateProductDto createProductDto)
        => await _productsCollection.InsertOneAsync(_mapper.Map<Product>(createProductDto));

    public async Task DeleteProductAsync(string productId)
        => await _productsCollection.DeleteOneAsync(x => x.ProductId == productId);

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
        => _mapper.Map<List<ResultProductDto>>(await _productsCollection.Find(x => true).ToListAsync());

    public async Task<GetByIdProductDto> GetByIdProductAsync(string productId)
        => _mapper.Map<GetByIdProductDto>(await _productsCollection.Find(x => x.ProductId == productId)
                                                                   .FirstOrDefaultAsync());

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        => await _productsCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId,
                                                                 _mapper.Map<Product>(updateProductDto));
}
