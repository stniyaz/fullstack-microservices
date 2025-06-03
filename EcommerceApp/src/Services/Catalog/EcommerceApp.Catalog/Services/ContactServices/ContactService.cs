using AutoMapper;
using EcommerceApp.Catalog.Dtos.ContactDtos;
using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.ContactServices;

public class ContactService : IContactService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Contact> _contactsCollection;

    public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _contactsCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
    }

    public async Task CreateContactAsync(CreateContactDto createContactDto)
        => await _contactsCollection.InsertOneAsync(_mapper.Map<Contact>(createContactDto));

    public async Task DeleteContactAsync(string contactId)
        => await _contactsCollection.DeleteOneAsync(x => x.ContactId == contactId);

    public async Task<List<ResultContactDto>> GetAllContactsAsync()
        => _mapper.Map<List<ResultContactDto>>(await _contactsCollection.Find(x => true).ToListAsync());
    public async Task<GetByIdContactDto> GetByIdContactAsync(string ContactId)
    {
        var value = await _contactsCollection.Find(x => x.ContactId == ContactId).FirstOrDefaultAsync();
        value.IsSeen = true;

        await _contactsCollection.ReplaceOneAsync(x => x.ContactId == value.ContactId, value);

        return _mapper.Map<GetByIdContactDto>(value);
    }
}
