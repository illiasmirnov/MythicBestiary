using System.ComponentModel.DataAnnotations;

namespace MythicBestiary.DTOs;

public class CreatureCreateDto
{
    [Required(ErrorMessage = "Назва істоти є обов’язковою.")]
    [MaxLength(100, ErrorMessage = "Назва істоти не повинна перевищувати 100 символів.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Slug є обов’язковим.")]
    [RegularExpression(
        "^[a-z0-9]+(?:-[a-z0-9]+)*$",
        ErrorMessage = "Slug може містити лише малі латинські літери, цифри та дефіси.")]
    [MaxLength(150, ErrorMessage = "Slug не повинен перевищувати 150 символів.")]
    public string Slug { get; set; } = string.Empty;

    [Required(ErrorMessage = "Опис є обов’язковим.")]
    [MinLength(20, ErrorMessage = "Опис має містити щонайменше 20 символів.")]
    [MaxLength(2000, ErrorMessage = "Опис не повинен перевищувати 2000 символів.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Категорія є обов’язковою.")]
    [MaxLength(100, ErrorMessage = "Категорія не повинна перевищувати 100 символів.")]
    public string Category { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = "Назва міфології не повинна перевищувати 100 символів.")]
    public string Mythology { get; set; } = string.Empty;

    [MaxLength(150, ErrorMessage = "Місце походження не повинно перевищувати 150 символів.")]
    public string Origin { get; set; } = string.Empty;

    [MaxLength(150, ErrorMessage = "Середовище існування не повинно перевищувати 150 символів.")]
    public string Habitat { get; set; } = string.Empty;

    [Required(ErrorMessage = "Рівень загрози є обов’язковим.")]
    [MaxLength(50, ErrorMessage = "Рівень загрози не повинен перевищувати 50 символів.")]
    public string ThreatLevel { get; set; } = string.Empty;

    public List<string> Abilities { get; set; } = new();

    public List<string> Weaknesses { get; set; } = new();

    public List<RelatedCreature> RelatedCreatures { get; set; } = new();

    public List<HistoricalNote> HistoricalNotes { get; set; } = new();

    public List<ImageResource> Images { get; set; } = new();

    public bool IsPublished { get; set; }
}