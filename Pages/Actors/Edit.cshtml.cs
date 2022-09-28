using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UsersStories.Data;
using UsersStories.Data.Entities;
using UsersStories.Models;

namespace UsersStories.Pages.Actors
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly UsersStories.Data.ApplicationDbContext _context;

        public EditModel(UsersStories.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActorModel Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);
            if (_actor == null)
            {
                return NotFound();
            }
            Actor = new ActorModel
            {
                Id=_actor.Id,
                Name=_actor.Name,
                Color=_actor.Color,
            };
            Actor.InitColors();
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Actor.InitColors();
                return Page();
            }
            var _actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == Actor.Id);
            _actor.Name = Actor.Name;
            _actor.Color = Actor.Color;

            _context.Attach(_actor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(Actor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ActorExists(string id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
