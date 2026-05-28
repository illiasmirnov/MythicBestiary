using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Pages.Creatures;

public class IndexModel : PageModel
{
    private readonly ICreatureService _creatureService;

    private const int PageSize = 10;

    public List<CreatureListDto> Creatures { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchQuery { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Mythology { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SortBy { get; set; }

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    public int TotalPages { get; set; }

    public int TotalCreatures { get; set; }

    public string? ErrorMessage { get; set; }

    public IndexModel(ICreatureService creatureService)
    {
        _creatureService = creatureService;
    }

    public async Task OnGet()
    {
        try
        {
            var creatures = await _creatureService.GetAllAsync();

            if (creatures is null)
            {
                Creatures = new List<CreatureListDto>();
                TotalPages = 0;
                TotalCreatures = 0;

                return;
            }

            var creatureList = creatures
                .Select(creature => new CreatureListDto())
                .ToList();

            // Поиск по имени
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                creatureList = creatureList
                    .Where(creature =>
                        creature.ToString()!
                            .Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Фильтрация по мифологии
            if (!string.IsNullOrWhiteSpace(Mythology))
            {
                creatureList = creatureList
                    .Where(creature =>
                        creature.ToString()!
                            .Contains(Mythology, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Сортировка
            creatureList = SortBy?.ToLower() switch
            {
                "name_desc" => creatureList
                    .OrderByDescending(creature => creature.ToString())
                    .ToList(),

                _ => creatureList
                    .OrderBy(creature => creature.ToString())
                    .ToList()
            };

            TotalCreatures = creatureList.Count;

            TotalPages = (int)Math.Ceiling(
                TotalCreatures / (double)PageSize);

            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }

            if (TotalPages > 0 && CurrentPage > TotalPages)
            {
                CurrentPage = TotalPages;
            }

            // Пагинация
            Creatures = creatureList
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
        catch
        {
            ErrorMessage = "Виникла помилка при завантаженні списку істот.";

            Creatures = new List<CreatureListDto>();

            TotalPages = 0;

            TotalCreatures = 0;
        }
    }
}