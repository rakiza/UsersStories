using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UsersStories.Data;
using UsersStories.Data.Entities;
using UsersStories.Models;

namespace UsersStories.Pages.Actors
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly UsersStories.Data.ApplicationDbContext _context;

        public CreateModel(UsersStories.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Actor = new();
            return Page();
        }

        [BindProperty]
        public ActorModel Actor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Actor.InitColors();
                return Page();
            }
            var actor = new Actor
            {
                Id = Guid.NewGuid().ToString(),
                Name = Actor.Name,
                Color = Actor.Color,
            };           
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
