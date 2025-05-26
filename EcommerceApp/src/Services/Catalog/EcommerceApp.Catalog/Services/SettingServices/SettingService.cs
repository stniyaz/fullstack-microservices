using AutoMapper;
using EcommerceApp.Catalog.Dtos.SettingDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.SettingServices;

public class SettingService : ISettingService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Setting> _settingCollection;

    public SettingService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _settingCollection = database.GetCollection<Setting>(_databaseSettings.SettingCollectionName);
    }

    public async Task DeleteSettingAsync(string id)
        => await _settingCollection.DeleteOneAsync(x => x.SettingId == id);

    public async Task<List<ResultSettingDto>> GetAllSettingsAsync()
        => _mapper.Map<List<ResultSettingDto>>(await _settingCollection.Find(x => true).ToListAsync());

    public async Task<GetByIdSettingDto> GetByIdSettingAsync(string id)
    =>
     _mapper.Map<GetByIdSettingDto>(await _settingCollection.Find(x => x.SettingId == id).FirstOrDefaultAsync());

    public async Task UpdateSettingAsync(UpdateSettingDto dto)
    {
        //=> await _settingCollection.FindOneAndReplaceAsync(x => x.SettingId == dto.SettingId,
        //                                                       _mapper.Map<Setting>(dto));
        var exist = await _settingCollection.Find(x => x.SettingId == dto.SettingId).FirstOrDefaultAsync();

        exist.Value = dto.Value;

        await _settingCollection.ReplaceOneAsync(x => x.SettingId == exist.SettingId, exist);
    }

    public async Task CreateSettingAsync(CreateSettingDto dto)
        => await _settingCollection.InsertOneAsync(_mapper.Map<Setting>(dto));
}
