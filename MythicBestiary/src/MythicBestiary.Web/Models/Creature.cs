using MongoDB.Bson.Serialization.Attributes;

namespace MythicBestiary.Web.Models;

public sealed class Creature
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("Title")]
    public string Title { get; set; } = string.Empty;

    [BsonElement("Text")]
    public string Text { get; set; } = string.Empty;

    [BsonElement("UserId")]
    [BsonIgnoreIfNull]
    public string? UserId { get; set; }

    [BsonElement("DangerLevel")]
    [BsonIgnoreIfNull]
    public double? DangerLevel { get; set; }

    [BsonElement("Status")]
    [BsonIgnoreIfNull]
    public string? Status { get; set; }

    [BsonElement("Habitat")]
    [BsonIgnoreIfNull]
    public string? Habitat { get; set; }

    [BsonElement("Abilities")]
    public List<string> Abilities { get; set; } = [];

    [BsonElement("Weaknesses")]
    public List<string> Weaknesses { get; set; } = [];

    [BsonElement("DiscoveredBy")]
    [BsonIgnoreIfNull]
    public BsonValue? DiscoveredBy { get; set; }

    [BsonElement("Notes")]
    [BsonIgnoreIfNull]
    public string? Notes { get; set; }

    [BsonElement("Climate")]
    [BsonIgnoreIfNull]
    public string? Climate { get; set; }

    [BsonElement("Loot")]
    public List<string> Loot { get; set; } = [];

    [BsonElement("Type")]
    [BsonIgnoreIfNull]
    public string? Type { get; set; }

    [BsonElement("Subspecies")]
    [BsonIgnoreIfNull]
    public string? Subspecies { get; set; }

    [BsonElement("SocialRole")]
    [BsonIgnoreIfNull]
    public string? SocialRole { get; set; }

    [BsonElement("Folklore")]
    [BsonIgnoreIfNull]
    public string? Folklore { get; set; }

    [BsonElement("Behavior")]
    [BsonIgnoreIfNull]
    public string? Behavior { get; set; }

    [BsonElement("CreatedAt")]
    [BsonIgnoreIfNull]
    public DateTime? CreatedAt { get; set; }

    [BsonElement("UpdatedAt")]
    [BsonIgnoreIfNull]
    public DateTime? UpdatedAt { get; set; }

    // Геодані потрібні для вимог лабораторної роботи №3-5 з MongoDB.
    [BsonElement("Location")]
    [BsonIgnoreIfNull]
    public GeoJsonPoint? Location { get; set; }
}

public sealed class GeoJsonPoint
{
    [BsonElement("type")]
    public string Type { get; set; } = "Point";

    // Формат GeoJSON: [довгота, широта].
    [BsonElement("coordinates")]
    public double[] Coordinates { get; set; } = [];
}