using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MythicBestiary.Web.Models
{
    public class Creature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("slug")]
        public string Slug { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;

        [BsonElement("mythology")]
        public string Mythology { get; set; } = string.Empty;

        [BsonElement("origin")]
        public string Origin { get; set; } = string.Empty;

        [BsonElement("threatLevel")]
        public string ThreatLevel { get; set; } = string.Empty;

        [BsonElement("abilities")]
        public List<string> Abilities { get; set; } = new();

        [BsonElement("weaknesses")]
        public List<string> Weaknesses { get; set; } = new();

        [BsonElement("relatedCreatures")]
        public List<RelatedCreature> RelatedCreatures { get; set; } = new();

        [BsonElement("historicalNotes")]
        public List<HistoricalNote> HistoricalNotes { get; set; } = new();

        [BsonElement("images")]
        public List<ImageResource> Images { get; set; } = new();

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isPublished")]
        public bool IsPublished { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("tags")]
        public List<string>? Tags { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("culture")]
        public string? Culture { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("shortDescription")]
        public string? ShortDescription { get; set; }
    }
}