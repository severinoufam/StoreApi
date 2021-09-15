﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreApi.Models
{
    public class Store
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("StoreName")]
        public string Name { get; set; }
    }
}