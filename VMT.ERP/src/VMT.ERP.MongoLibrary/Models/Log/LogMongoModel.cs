using MongoDB.Bson.Serialization.Attributes;

namespace VMT.ERP.MongoLibrary.Models.Log
{
    public class LogMongoModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public object? Data { get; set; }
        public bool IsError { get; set; }

        [BsonElement("DateTime")]
        public DateTime Date { get; set; }
    }
}