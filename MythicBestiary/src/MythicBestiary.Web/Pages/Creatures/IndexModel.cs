using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Web.Pages.Creatures;

public sealed class IndexModel : PageModel
{
    private const int PageSize = 10;

    private readonly ICreatureService _creatureService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        ICreatureService creatureService,
        ILogger<IndexModel> logger)
    {
        _creatureService = creatureService;
        _logger = logger;
    }

    public List<CreatureListDto> Creatures { get; private set; } = [];

    [BindProperty(SupportsGet = true)]
    public string? SearchQuery { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Status { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SortBy { get; set; }

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    public int TotalPages { get; private set; }

    public int TotalCreatures { get; private set; }

    public string? ErrorMessage { get; private set; }

    public async Task OnGetAsync()
    {
        try
        {
            var creatureList = (await _creatureService.GetAllAsync()).ToList();

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                creatureList = creatureList
                    .Where(creature =>
                        Contains(creature.Title, SearchQuery) ||
                        Contains(creature.Text, SearchQuery) ||
                        Contains(creature.Habitat, SearchQuery))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(Status))
            {
                creatureList = creatureList
                    .Where(creature => Contains(creature.Status, Status))
                    .ToList();
            }

            creatureList = SortBy?.ToLowerInvariant() switch
            {
                "title_desc" => creatureList.OrderByDescending(creature => creature.Title).ToList(),
                "danger_asc" => creatureList.OrderBy(creature => creature.DangerLevel).ToList(),
                "danger_desc" => creatureList.OrderByDescending(creature => creature.DangerLevel).ToList(),
                _ => creatureList.OrderBy(creature => creature.Title).ToList()
            };

            TotalCreatures = creatureList.Count;
            TotalPages = (int)Math.Ceiling(TotalCreatures / (double)PageSize);

            CurrentPage = Math.Max(CurrentPage, 1);

            if (TotalPages > 0 && CurrentPage > TotalPages)
            {
                CurrentPage = TotalPages;
            }

            Creatures = creatureList
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Помилка під час завантаження списку істот.");

            ErrorMessage = "Не вдалося завантажити список істот. Спробуйте ще раз.";
            Creatures = [];
            TotalPages = 0;
            TotalCreatures = 0;
        }
    }

    private static bool Contains(string? source, string value)
    {
        return !string.IsNullOrWhiteSpace(source)
            && source.Contains(value, StringComparison.OrdinalIgnoreCase);
    }
}