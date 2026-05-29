namespace MythicBestiary.DTOs;

public class CreatureResponseDto
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Mythology { get; set; } = string.Empty;

    public string Origin { get; set; } = string.Empty;

    public string Habitat { get; set; } = string.Empty;

    public string ThreatLevel { get; set; } = string.Empty;

    public List<string> Abilities { get; set; } = new();

    public List<string> Weaknesses { get; set; } = new();

    public List<string> ImageUrls { get; set; } = new();

    public List<string> HistoricalNotes { get; set; } = new();

    public List<string> RelatedCreatures { get; set; } = new();

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsPublished { get; set; }
}