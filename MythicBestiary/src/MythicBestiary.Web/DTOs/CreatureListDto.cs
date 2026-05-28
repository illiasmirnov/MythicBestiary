namespace MythicBestiary.DTOs;

public class CreatureListDto
{
    // Ідентифікатор
    public string Id { get; set; } = string.Empty;

    // Назва істоти
    public string Name { get; set; } = string.Empty;

    // URL-friendly назва
    public string Slug { get; set; } = string.Empty;

    // Короткий опис для списку
    public string ShortDescription { get; set; } = string.Empty;

    // Тип або категорія істоти
    public string Category { get; set; } = string.Empty;

    // Міфологія або культура походження
    public string Mythology { get; set; } = string.Empty;

    // Походження або середовище існування
    public string Origin { get; set; } = string.Empty;

    // Рівень загрози
    public string ThreatLevel { get; set; } = string.Empty;

    // Мініатюра головного зображення
    public string ThumbnailUrl { get; set; } = string.Empty;

    // Статус публікації
    public bool IsPublished { get; set; }

    // Дата створення
    public DateTime CreatedAt { get; set; }

    // Дата останнього оновлення
    public DateTime UpdatedAt { get; set; }
}