using AutoMapper;
using EcommerceApp.Catalog.Dtos.ProductDetailDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;

    private readonly IMongoCollection<ProductDetail> _productsCollection;
    public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productsCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        => await _productsCollection.InsertOneAsync(_mapper.Map<ProductDetail>(createProductDetailDto));

    public async Task DeleteProductDetailAsync(string productDetailId)
        => await _productsCollection.DeleteOneAsync(x => x.ProductDetailId == productDetailId);

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        => _mapper.Map<List<ResultProductDetailDto>>(await _productsCollection.Find(x => true).ToListAsync());

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId)
        => _mapper.Map<GetByIdProductDetailDto>(await _productsCollection.Find(x => productDetailId == x.ProductDetailId).FirstOrDefaultAsync());

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        => await _productsCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDetailDto.ProductId,
                                                                _mapper.Map<ProductDetail>(updateProductDetailDto));
}
