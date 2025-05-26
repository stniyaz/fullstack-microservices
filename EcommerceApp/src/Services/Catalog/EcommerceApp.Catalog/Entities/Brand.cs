using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EcommerceApp.Catalog.Entities;

public class Brand
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string BrandId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}
