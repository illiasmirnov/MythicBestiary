using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Web.Pages.Creatures
{
    public class DeleteModel : PageModel
    {
        private readonly ICreatureService _creatureService;

        public DeleteModel(ICreatureService creatureService)
        {
            _creatureService = creatureService;
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

            if (Creature == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            try
            {
                var existingCreature = await _creatureService.GetByIdAsync(id);

                if (existingCreature == null)
                {
                    return NotFound();
                }

                await _creatureService.DeleteAsync(id);

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ErrorMessage = "An error occurred while deleting the creature.";

                Creature = await _creatureService.GetByIdAsync(id);

                return Page();
            }
        }
    }
}