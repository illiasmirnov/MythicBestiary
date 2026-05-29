
namespace MythicBestiary.Web.Models;

public sealed class RelatedCreature
{
    [BsonElement("RelatedCreatureId")]
    public string RelatedCreatureId { get; set; } = string.Empty;

    [BsonElement("Title")]
    public string Title { get; set; } = string.Empty;

    [BsonElement("RelationType")]
    public string RelationType { get; set; } = string.Empty;

    [BsonElement("Text")]
    [BsonIgnoreIfNull]
    public string? Text { get; set; }

    [BsonElement("Category")]
    [BsonIgnoreIfNull]
    public string? Category { get; set; }

    [BsonElement("SignificanceLevel")]
    [BsonIgnoreIfNull]
    public double? SignificanceLevel { get; set; }

    [BsonElement("IsBidirectional")]
    public bool IsBidirectional { get; set; }

    public bool IsValidFor(string currentCreatureId)
    {
        return !string.IsNullOrWhiteSpace(RelatedCreatureId)
            && !string.Equals(
                RelatedCreatureId,
                currentCreatureId,
                StringComparison.OrdinalIgnoreCase);
    }
}