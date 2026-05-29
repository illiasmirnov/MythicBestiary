using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Web.Pages.Creatures;

public sealed class DetailsModel : PageModel
{
    private readonly ICreatureService _creatureService;
    private readonly ILogger<DetailsModel> _logger;

    public DetailsModel(
        ICreatureService creatureService,
        ILogger<DetailsModel> logger)
    {
        _creatureService = creatureService;
        _logger = logger;
    }

    public CreatureResponseDto? Creature { get; private set; }

    public string? ErrorMessage { get; private set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return NotFound();
        }

        try
        {
            Creature = await _creatureService.GetByIdAsync(id);

            return Creature is null ? NotFound() : Page();
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Помилка під час завантаження істоти з ідентифікатором {CreatureId}.",
                id);

            ErrorMessage = "Не вдалося завантажити дані істоти. Спробуйте ще раз.";
            return Page();
        }
    }
}