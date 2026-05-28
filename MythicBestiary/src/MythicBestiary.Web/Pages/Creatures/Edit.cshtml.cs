using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Web.Pages.Creatures
{
    public class EditModel : PageModel
    {
        private readonly ICreatureService _creatureService;

        public EditModel(ICreatureService creatureService)
        {
            _creatureService = creatureService;
        }

        [BindProperty]
        public CreatureUpdateDto Creature { get; set; } = new();

        public string? ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var existingCreature = await _creatureService.GetByIdAsync(id);

            if (existingCreature == null)
            {
                return NotFound();
            }

            Creature = new CreatureUpdateDto
            {
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _creatureService.UpdateAsync(Creature);

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ErrorMessage = "An error occurred while updating the creature.";

                return Page();
            }
        }
    }
}