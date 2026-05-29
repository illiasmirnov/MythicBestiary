using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Web.Pages.Creatures;

public sealed class DeleteModel : PageModel
{
    private readonly ICreatureService _creatureService;
    private readonly ILogger<DeleteModel> _logger;

    public DeleteModel(
        ICreatureService creatureService,
        ILogger<DeleteModel> logger)
    {
        _creatureService = creatureService;
        _logger = logger;
    }

    [BindProperty]
    public CreatureResponseDto? Creature { get; set; }

    public string? ErrorMessage { get; private set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return NotFound();
        }

        Creature = await _creatureService.GetByIdAsync(id);

        return Creature is null ? NotFound() : Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return NotFound();
        }

        try
        {
            await _creatureService.DeleteAsync(id);

            TempData["SuccessMessage"] = "Істоту успішно видалено.";
            return RedirectToPage("./Index");
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Помилка під час видалення істоти з ідентифікатором {CreatureId}.",
                id);

            ErrorMessage = "Не вдалося видалити істоту. Спробуйте ще раз.";

            Creature = await _creatureService.GetByIdAsync(id);
            return Creature is null ? NotFound() : Page();
        }
    }
}