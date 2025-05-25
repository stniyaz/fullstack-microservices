using AutoMapper;
using EcommerceApp.Catalog.Dtos.FeatureDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.FeatureServices;

public class FeatureService : IFeatureService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Feature> _featureCollection;
    public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
    }

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        => await _featureCollection.InsertOneAsync(_mapper.Map<Feature>(createFeatureDto));

    public async Task DeleteFeatureAsync(string featureId)
        => await _featureCollection.DeleteOneAsync(x => x.FeatureId == featureId);

    public async Task<List<ResultFeatureDto>> GetAllCategoriesAsync()
        => _mapper.Map<List<ResultFeatureDto>>(await _featureCollection.Find(x => true).ToListAsync());

    public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string featureId)
        => _mapper.Map<GetByIdFeatureDto>(await _featureCollection.Find(x => x.FeatureId == featureId)
                                                                  .FirstOrDefaultAsync());

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        => await _featureCollection.ReplaceOneAsync(x => x.FeatureId == updateFeatureDto.FeatureId,
                                                         _mapper.Map<Feature>(updateFeatureDto));
}
