using MongoDB.Bson.Serialization.Attributes;

namespace VMT.ERP.MongoLibrary.Models.WorkProcess
{
    public class WorkerProcessMongo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public object? Data { get; set; }
        public string? Process {  get; set; }

        [BsonElement("DateTime")]
        public DateTime Date { get; set; }
        [BsonElement("DateTimeProcess")]
        public DateTime DateProcess { get; set; }
    }
}