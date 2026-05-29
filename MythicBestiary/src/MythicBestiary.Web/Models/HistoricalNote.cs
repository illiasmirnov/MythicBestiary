
namespace MythicBestiary.Web.Models;

public sealed class HistoricalNote
{
    [BsonElement("Title")]
    public string Title { get; set; } = string.Empty;

    [BsonElement("Text")]
    public string Text { get; set; } = string.Empty;

    [BsonElement("Source")]
    [BsonIgnoreIfNull]
    public string? Source { get; set; }

    [BsonElement("Author")]
    [BsonIgnoreIfNull]
    public string? Author { get; set; }

    [BsonElement("EventDate")]
    [BsonIgnoreIfNull]
    public DateTime? EventDate { get; set; }

    [BsonElement("NoteType")]
    [BsonIgnoreIfNull]
    public string? NoteType { get; set; }

    [BsonElement("Culture")]
    [BsonIgnoreIfNull]
    public string? Culture { get; set; }

    [BsonElement("Civilization")]
    [BsonIgnoreIfNull]
    public string? Civilization { get; set; }

    [BsonElement("HistoricalPeriod")]
    [BsonIgnoreIfNull]
    public string? HistoricalPeriod { get; set; }

    [BsonElement("AdditionalNotes")]
    [BsonIgnoreIfNull]
    public string? AdditionalNotes { get; set; }

    [BsonElement("Tags")]
    public List<string> Tags { get; set; } = [];

    [BsonElement("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}