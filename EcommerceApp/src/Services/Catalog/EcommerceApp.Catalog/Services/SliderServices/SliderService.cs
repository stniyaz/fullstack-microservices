using AutoMapper;
using EcommerceApp.Catalog.Dtos.SliderDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.SliderServices;

public class SliderService : ISliderService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Slider> _slidersCollection;
    public SliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _slidersCollection = database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);
    }

    public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        => await _slidersCollection.InsertOneAsync(_mapper.Map<Slider>(createSliderDto));

    public async Task DeleteSliderAsync(string sliderId)
        => await _slidersCollection.DeleteOneAsync(x => x.SliderId == sliderId);

    public async Task<List<ResultSliderDto>> GetAllSlidersAsync()
        => _mapper.Map<List<ResultSliderDto>>(await _slidersCollection.Find(x => true).ToListAsync());

    public async Task<GetByIdSliderDto> GetByIdSliderAsync(string sliderId)
        => _mapper.Map<GetByIdSliderDto>(await _slidersCollection.Find(x => x.SliderId == sliderId)
                                                                 .FirstOrDefaultAsync());

    public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        => await _slidersCollection.ReplaceOneAsync(x => x.SliderId == updateSliderDto.SliderId,
                                                         _mapper.Map<Slider>(updateSliderDto));
}
