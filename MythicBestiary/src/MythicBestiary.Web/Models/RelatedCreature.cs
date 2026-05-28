using MongoDB.Bson.Serialization.Attributes;

namespace MythicBestiary.Web.Models
{
    public class RelatedCreature
    {
        [BsonElement("relatedCreatureId")]
        public string RelatedCreatureId { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("relationType")]
        public string RelationType { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonIgnoreIfNull]
        [BsonElement("mythology")]
        public string? Mythology { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("category")]
        public string? Category { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("significanceLevel")]
        public string? SignificanceLevel { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("isBidirectional")]
        public bool? IsBidirectional { get; set; }
    }
}