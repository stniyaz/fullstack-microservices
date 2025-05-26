using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EcommerceApp.Catalog.Entities;

public class Setting
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string SettingId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
