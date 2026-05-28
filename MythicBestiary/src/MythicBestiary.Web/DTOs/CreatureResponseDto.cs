namespace MythicBestiary.DTOs;

public class CreatureResponseDto
{
    // Ідентифікатор
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

    // Зображення
    public List<string> ImageUrls { get; set; } = new();

    // Історичні нотатки
    public List<string> HistoricalNotes { get; set; } = new();

    // Пов’язані істоти
    public List<string> RelatedCreatures { get; set; } = new();

    // Дата створення
    public DateTime CreatedAt { get; set; }

    // Дата оновлення
    public DateTime UpdatedAt { get; set; }

    // Статус публікації
    public bool IsPublished { get; set; }

    // TODO:
    // Додати SEO metadata

    // TODO:
    // Додати статистику переглядів

    // TODO:
    // Додати розширені дані галереї
}