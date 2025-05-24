using AutoMapper;
using EcommerceApp.Catalog.Dtos.SpecialOfferDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.SpecialOfferServices;

public class SpecialOfferService : ISpecialOfferService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<SpecialOffer> _specialOffersCollection;
    public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _specialOffersCollection =
            database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
    }

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        => await _specialOffersCollection.InsertOneAsync(_mapper.Map<SpecialOffer>(createSpecialOfferDto));

    public async Task DeleteSpecialOfferAsync(string SpecialOfferId)
        => await _specialOffersCollection.DeleteOneAsync(x => x.SpecialOfferId == SpecialOfferId);

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
        => _mapper.Map<List<ResultSpecialOfferDto>>(await _specialOffersCollection.Find(x => true)
                                                                                  .ToListAsync());

    public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string SpecialOfferId)
        => _mapper.Map<GetByIdSpecialOfferDto>(await _specialOffersCollection
                  .Find(x => x.SpecialOfferId == SpecialOfferId).FirstOrDefaultAsync());

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        => await _specialOffersCollection.ReplaceOneAsync(x =>
                                        x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId,
                                        _mapper.Map<SpecialOffer>(updateSpecialOfferDto));
}
