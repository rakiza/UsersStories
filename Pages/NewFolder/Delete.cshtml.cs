using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UsersStories.Data;
using UsersStories.Data.Entities;

namespace UsersStories.Pages.NewFolder
{
    public class DeleteModel : PageModel
    {
        private readonly UsersStories.Data.ApplicationDbContext _context;

        public DeleteModel(UsersStories.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _context.Actors.FindAsync(id);

            if (Actor != null)
            {
                _context.Actors.Remove(Actor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
