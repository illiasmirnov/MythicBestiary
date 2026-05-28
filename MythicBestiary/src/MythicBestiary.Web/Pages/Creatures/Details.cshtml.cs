using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Web.Pages.Creatures
{
    public class DetailsModel : PageModel
    {
        private readonly ICreatureService _creatureService;

        public DetailsModel(ICreatureService creatureService)
        {
            _creatureService = creatureService;
        }

        public CreatureResponseDto? Creature { get; private set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            Creature = await _creatureService.GetByIdAsync(id);

            if (Creature == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}