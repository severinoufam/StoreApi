using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Active { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
