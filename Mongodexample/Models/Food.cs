
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Text.Json.Serialization;

namespace Mongodexample.Models;

    public class Food
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string name { get; set; } = null!;
        public string brand { get; set; } = null!;
        public decimal weight { get; set; }
        public decimal calories { get; set; }
        public decimal carbohydrate { get; set; }
        public decimal sugar { get; set; }
        public decimal fat { get; set; }
        public decimal protiens { get; set; }
        public decimal sel { get; set; }
        public string img { get; set; } = null!;
        public string category { get; set; } = null!;

}
