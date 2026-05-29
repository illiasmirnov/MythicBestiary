namespace MythicBestiary.DTOs;

public class CreatureListDto
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Mythology { get; set; } = string.Empty;

    public string Origin { get; set; } = string.Empty;

    public string Habitat { get; set; } = string.Empty;

    public string ThreatLevel { get; set; } = string.Empty;

    public int AbilitiesCount { get; set; }

    public string ThumbnailUrl { get; set; } = string.Empty;

    public bool IsPublished { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}