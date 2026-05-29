using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Web.Pages;

public sealed class IndexModel : PageModel
{
    private readonly ICreatureService _creatureService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        ICreatureService creatureService,
        ILogger<IndexModel> logger)
    {
        _creatureService = creatureService;
        _logger = logger;
    }

    public List<CreatureListDto> PopularCreatures { get; private set; } = [];

    public int TotalCreaturesCount { get; private set; }

    public string? ErrorMessage { get; private set; }

    public async Task OnGetAsync()
    {
        try
        {
            var creatures = (await _creatureService.GetAllAsync()).ToList();

            TotalCreaturesCount = creatures.Count;

            // Для головної сторінки показуємо найбільш небезпечних істот.
            PopularCreatures = creatures
                .OrderByDescending(creature => creature.DangerLevel)
                .ThenBy(creature => creature.Title)
                .Take(6)
                .ToList();
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Помилка під час завантаження даних головної сторінки бестіарію.");

            ErrorMessage = "Не вдалося завантажити дані бестіарію. Спробуйте ще раз.";
            PopularCreatures = [];
            TotalCreaturesCount = 0;
        }
    }
}