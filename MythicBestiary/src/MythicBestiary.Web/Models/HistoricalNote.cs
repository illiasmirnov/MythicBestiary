using MongoDB.Bson.Serialization.Attributes;

namespace MythicBestiary.Web.Models
{
    public class HistoricalNote
    {
        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("content")]
        public string Content { get; set; } = string.Empty;

        [BsonElement("source")]
        public string Source { get; set; } = string.Empty;

        [BsonElement("author")]
        public string Author { get; set; } = string.Empty;

        [BsonElement("eventDate")]
        public DateTime? EventDate { get; set; }

        [BsonElement("noteType")]
        public string NoteType { get; set; } = string.Empty;

        [BsonIgnoreIfNull]
        [BsonElement("culture")]
        public string? Culture { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("civilization")]
        public string? Civilization { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("historicalPeriod")]
        public string? HistoricalPeriod { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("referenceUrl")]
        public string? ReferenceUrl { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("additionalNotes")]
        public string? AdditionalNotes { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("tags")]
        public List<string>? Tags { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}