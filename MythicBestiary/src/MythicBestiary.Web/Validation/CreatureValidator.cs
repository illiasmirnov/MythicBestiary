using FluentValidation;
using MythicBestiary.DTOs;

namespace MythicBestiary.Validation;

public class CreatureValidator : AbstractValidator<CreatureCreateDto>
{
    public CreatureValidator()
    {
        // Проверка названия

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Creature name is required.")
            .MaximumLength(100)
            .WithMessage("Creature name is too long.");

        // Проверка slug

        RuleFor(x => x.Slug)
            .NotEmpty()
            .WithMessage("Slug is required.");

        // Проверка описания

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        // Проверка категории

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required.");

        // Проверка мифологии

        RuleFor(x => x.Mythology)
            .NotEmpty()
            .WithMessage("Mythology is required.");

        // Проверка происхождения

        RuleFor(x => x.Origin)
            .NotEmpty()
            .WithMessage("Origin is required.");

        // Проверка уровня угрозы

        RuleFor(x => x.ThreatLevel)
            .NotEmpty()
            .WithMessage("Threat level is required.");

        // Проверка способностей

        RuleFor(x => x.Abilities)
            .NotNull()
            .WithMessage("Abilities collection is required.");

        // Проверка слабостей

        RuleFor(x => x.Weaknesses)
            .NotNull()
            .WithMessage("Weaknesses collection is required.");

        // TODO:
        // Добавить regex validation для slug

        // TODO:
        // Добавить проверку уникальности slug

        // TODO:
        // Добавить sanitization validation

        // TODO:
        // Добавить forbidden symbols validation

        // TODO:
        // Добавить business rules validation
    }

    // TODO:
    // Добавить validation для CreatureUpdateDto

    // TODO:
    // Добавить async validation rules

    // TODO:
    // Добавить custom validation methods
}