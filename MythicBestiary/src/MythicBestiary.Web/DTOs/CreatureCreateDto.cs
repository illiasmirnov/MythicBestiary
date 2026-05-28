using System.ComponentModel.DataAnnotations;
using MythicBestiary.Models;

namespace MythicBestiary.DTOs;

public class CreatureCreateDto
{
    // Название существа
    [Required(ErrorMessage = "Назва істоти є обов'язковою.")]
    [MaxLength(100, ErrorMessage = "Назва істоти не повинна перевищувати 100 символів.")]
    public string Name { get; set; } = string.Empty;

    // URL slug
    [Required(ErrorMessage = "Slug обов'язковий.")]
    [MaxLength(150, ErrorMessage = "Slug не повинен перевищувати 150 символів.")]
    public string Slug { get; set; } = string.Empty;

    // Полное описание
    [Required(ErrorMessage = "Опис є обов'язковим.")]
    [MinLength(20, ErrorMessage = "Опис має містити щонайменше 20 символів.")]
    public string Description { get; set; } = string.Empty;

    // Категория существа
    [MaxLength(100, ErrorMessage = "Категорія не повинна перевищувати 100 символів.")]
    public string Category { get; set; } = string.Empty;

    // Мифология
    [MaxLength(100, ErrorMessage = "Назва міфології не повинна перевищувати 100 символів.")]
    public string Mythology { get; set; } = string.Empty;

    // Регион происхождения
    [MaxLength(150, ErrorMessage = "Регіон походження не повинен перевищувати 150 символів.")]
    public string Origin { get; set; } = string.Empty;

    // Уровень угрозы
    [MaxLength(50, ErrorMessage = "Рівень загрози не повинен перевищувати 50 символів.")]
    public string ThreatLevel { get; set; } = string.Empty;

    // Способности
    public List<string> Abilities { get; set; } = new();

    // Слабости
    public List<string> Weaknesses { get; set; } = new();

    // Связанные существа
    public List<RelatedCreature> RelatedCreatures { get; set; } = new();

    // Исторические заметки
    public List<HistoricalNote> HistoricalNotes { get; set; } = new();

    // Изображения
    public List<ImageResource> Images { get; set; } = new();

    // Публикация записи
    public bool IsPublished { get; set; }

    // TODO:
    // Добавить DTO изображений

    // TODO:
    // Добавить DTO исторических заметок

    // TODO:
    // Добавить расширенную валидацию
}