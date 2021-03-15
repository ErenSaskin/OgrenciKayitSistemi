using MongoDB.Bson.Serialization.Attributes;

namespace OgrenciKayitSistemi.Models
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonIgnoreIfDefault, BsonIgnoreIfNull]
        public string Id { get; set; }
    }
}
