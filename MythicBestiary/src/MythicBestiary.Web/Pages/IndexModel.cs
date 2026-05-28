using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Pages;

public class IndexModel : PageModel
{
    private readonly ICreatureService _creatureService;

    public List<object> PopularCreatures { get; set; } = new();

    public int TotalCreaturesCount { get; set; }

    public string? ErrorMessage { get; set; }

    public IndexModel(ICreatureService creatureService)
    {
        _creatureService = creatureService;
    }

    public async Task OnGet()
    {
        try
        {
            // Получение данных через сервисный слой
            var creatures = await _creatureService.GetAllAsync();

            if (creatures is null)
            {
                PopularCreatures = new List<object>();
                TotalCreaturesCount = 0;

                return;
            }

            // Общее количество существ
            TotalCreaturesCount = creatures.Count();

            // Подготовка популярных существ для главной страницы
            PopularCreatures = creatures
                .Take(6)
                .Cast<object>()
                .ToList();
        }
        catch
        {
            ErrorMessage = "Виникла помилка при завантаженні даних бестіарію.";

            PopularCreatures = new List<object>();

            TotalCreaturesCount = 0;
        }
    }
}