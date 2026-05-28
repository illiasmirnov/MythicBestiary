using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Services.Interfaces;

namespace MythicBestiary.Web.Pages.Creatures
{
    public class CreateModel : PageModel
    {
        private readonly ICreatureService _creatureService;

        public CreateModel(ICreatureService creatureService)
        {
            _creatureService = creatureService;
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
                return Page();
            }

            try
            {
                await _creatureService.CreateAsync(Creature);

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ErrorMessage = "An error occurred while creating the creature.";

                return Page();
            }
        }
    }
}