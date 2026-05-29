using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Repositories.Interfaces;

namespace MythicBestiary.Web.Pages.Creatures;

public sealed class CreateModel : PageModel
{
    private readonly ICreatureRepository _creatureRepository;
    private readonly ILogger<CreateModel> _logger;

    public CreateModel(
        ICreatureRepository creatureRepository,
        ILogger<CreateModel> logger)
    {
        _creatureRepository = creatureRepository;
        _logger = logger;
    }

    [BindProperty]
    public CreatureCreateDto Creature { get; set; } = new();

    public string? ErrorMessage { get; private set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ErrorMessage = "Перевірте правильність заповнення форми.";
            return Page();
        }

        try
        {
            await _creatureRepository.CreateAsync(Creature);

            TempData["SuccessMessage"] = "Істоту успішно створено.";
            return RedirectToPage("./Index");
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Помилка під час створення істоти.");

            ErrorMessage = "Не вдалося створити істоту. Спробуйте ще раз.";

            return Page();
        }
    }
}