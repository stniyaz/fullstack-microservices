﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Reflection.Metadata.Ecma335;

namespace EcommerceApp.Catalog.Entities;

public class ProductImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductImageId { get; set; }
    public string ProductImage1 { get; set; }
    public string ProductImage2 { get; set; }
    public string ProductImage3 { get; set; }

    public string ProductId { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}
