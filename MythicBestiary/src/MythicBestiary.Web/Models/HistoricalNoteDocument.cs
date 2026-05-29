using MongoDB.Bson.Serialization.Attributes;

namespace MythicBestiary.Web.Models;

public sealed class HistoricalNoteDocument : HistoricalNote
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("CreatureId")]
    public string CreatureId { get; set; } = string.Empty;

    [BsonElement("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("UpdatedAt")]
    [BsonIgnoreIfNull]
    public DateTime? UpdatedAt { get; set; }

    public bool HasValidCreatureReference()
    {
        return !string.IsNullOrWhiteSpace(CreatureId);
    }
}