using AutoMapper;
using EcommerceApp.Catalog.Dtos.BrandDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Brand> _brandCollection;
    public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
    }
    public async Task CreateBrandAsync(CreateBrandDto dto)
        => await _brandCollection.InsertOneAsync(_mapper.Map<Brand>(dto));

    public async Task DeleteBrandAsync(string id)
        => await _brandCollection.DeleteOneAsync(x => x.BrandId == id);

    public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        => _mapper.Map<List<ResultBrandDto>>(await _brandCollection.Find(x => true).ToListAsync());

    public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        => _mapper.Map<GetByIdBrandDto>(await _brandCollection.Find(x => x.BrandId == id).FirstOrDefaultAsync());

    public async Task UpdateBrandAsync(UpdateBrandDto dto)
        => await _brandCollection.ReplaceOneAsync(x => x.BrandId == dto.BrandId, _mapper.Map<Brand>(dto));
}
