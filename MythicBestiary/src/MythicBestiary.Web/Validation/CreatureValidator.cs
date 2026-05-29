using MythicBestiary.DTOs;

namespace MythicBestiary.Validation;

public class CreatureValidator : AbstractValidator<CreatureCreateDto>
{
    public CreatureValidator()
    {
        Include(new CreatureBaseValidator<CreatureCreateDto>());
    }
}

public class CreatureUpdateValidator : AbstractValidator<CreatureUpdateDto>
{
    public CreatureUpdateValidator()
    {
        Include(new CreatureBaseValidator<CreatureUpdateDto>());
    }
}

public class CreatureBaseValidator<T> : AbstractValidator<T>
    where T : class
{
    public CreatureBaseValidator()
    {
        RuleFor(x => GetString(x, "Name"))
            .NotEmpty().WithMessage("Назва істоти є обов’язковою.")
            .MaximumLength(100).WithMessage("Назва істоти не може перевищувати 100 символів.")
            .Must(NotContainHtml).WithMessage("Назва істоти не повинна містити HTML або скрипти.");

        RuleFor(x => GetString(x, "Slug"))
            .NotEmpty().WithMessage("Slug є обов’язковим.")
            .MaximumLength(120).WithMessage("Slug не може перевищувати 120 символів.")
            .Matches("^[a-z0-9]+(?:-[a-z0-9]+)*$")
            .WithMessage("Slug може містити лише малі латинські літери, цифри та дефіси між словами.");

        RuleFor(x => GetString(x, "Description"))
            .NotEmpty().WithMessage("Опис істоти є обов’язковим.")
            .MaximumLength(3000).WithMessage("Опис істоти не може перевищувати 3000 символів.")
            .Must(NotContainHtml).WithMessage("Опис не повинен містити HTML або скрипти.");

        RuleFor(x => GetString(x, "Category"))
            .NotEmpty().WithMessage("Категорія істоти є обов’язковою.")
            .MaximumLength(80).WithMessage("Категорія не може перевищувати 80 символів.");

        RuleFor(x => GetString(x, "Mythology"))
            .NotEmpty().WithMessage("Міфологія є обов’язковою.")
            .MaximumLength(120).WithMessage("Назва міфології не може перевищувати 120 символів.");

        RuleFor(x => GetString(x, "Origin"))
            .NotEmpty().WithMessage("Походження істоти є обов’язковим.")
            .MaximumLength(200).WithMessage("Походження не може перевищувати 200 символів.");

        RuleFor(x => GetString(x, "ThreatLevel"))
            .NotEmpty().WithMessage("Рівень небезпеки є обов’язковим.")
            .MaximumLength(50).WithMessage("Рівень небезпеки не може перевищувати 50 символів.");

        RuleFor(x => GetCollection(x, "Abilities"))
            .NotNull().WithMessage("Список здібностей є обов’язковим.")
            .Must(items => items is not null && items.Any())
            .WithMessage("Потрібно вказати хоча б одну здібність.");

        RuleFor(x => GetCollection(x, "Weaknesses"))
            .NotNull().WithMessage("Список слабкостей є обов’язковим.")
            .Must(items => items is not null && items.Any())
            .WithMessage("Потрібно вказати хоча б одну слабкість.");
    }

    private static string? GetString(T instance, string propertyName)
    {
        return typeof(T).GetProperty(propertyName)?.GetValue(instance) as string;
    }

    private static IEnumerable<string>? GetCollection(T instance, string propertyName)
    {
        return typeof(T).GetProperty(propertyName)?.GetValue(instance) as IEnumerable<string>;
    }

    private static bool NotContainHtml(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return true;
        }

        return !value.Contains('<') && !value.Contains('>');
    }
}