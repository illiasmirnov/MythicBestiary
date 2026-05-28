using System.Collections.Generic;

namespace MythicBestiary.DTOs;

public class CreatureResponseDto
{
    // Ідентифікатор істоти
    public string Id { get; set; } = string.Empty;

    // Назва
    public string Name { get; set; } = string.Empty;

    // Slug
    public string Slug { get; set; } = string.Empty;

    // Опис
    public string Description { get; set; } = string.Empty;

    // Категорія
    public string Category { get; set; } = string.Empty;

    // Міфологія
    public string Mythology { get; set; } = string.Empty;

    // Походження
    public string Origin { get; set; } = string.Empty;

    // Рівень загрози
    public string ThreatLevel { get; set; } = string.Empty;

    // Здібності
    public List<string> Abilities { get; set; } = new();

    // Слабкості
    public List<string> Weaknesses { get; set; } = new();

    // Пов’язані істоти
    public List<RelatedCreatureDto> RelatedCreatures { get; set; } = new();

    // Історичні нотатки
    public List<HistoricalNoteDto> HistoricalNotes { get; set; } = new();

    // Зображення
    public List<ImageResourceDto> Images { get; set; } = new();

    // Ознака публікації
    public bool IsPublished { get; set; }

    // =========================
    // DTO SUPPORT CLASSES
    // =========================

    public class RelatedCreatureDto
    {
        public string CreatureId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string RelationType { get; set; } = string.Empty;
    }

    public class HistoricalNoteDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

    public class ImageResourceDto
    {
        public string Url { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;
    }
}