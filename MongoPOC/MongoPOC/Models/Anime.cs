﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoPOC.Models
{
    public class Anime
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
