using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UsersStories.Data;
using UsersStories.Data.Entities;

namespace UsersStories.Pages.Contexts
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly UsersStories.Data.ApplicationDbContext _context;

        public DeleteModel(UsersStories.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Context Context { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Context = await _context.Contexts.FirstOrDefaultAsync(m => m.Id == id);

            if (Context == null)
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
            Context = await _context.Contexts.FindAsync(id);

            if (Context != null)
            {
                var stories = _context.Stories.Where(s => s.ContextId == id);
                if (stories.Any())
                {
                    stories.ToList().ForEach(s =>
                    {
                        s.ContextId = null;
                        _context.Entry(s).State = EntityState.Modified;
                    });
                }
                _context.Contexts.Remove(Context);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
