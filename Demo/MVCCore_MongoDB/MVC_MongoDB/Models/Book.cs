using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MVC_MongoDB.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

        public string Author { get; set; } = null!;
        public byte[] Picture { get; set; }
    }
}

