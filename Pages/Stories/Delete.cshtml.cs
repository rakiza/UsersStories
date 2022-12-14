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

namespace UsersStories.Pages.Stories
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
        public Story Story { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Story = await _context.Stories
                .Include(s => s.Actor).FirstOrDefaultAsync(m => m.Id == id);

            if (Story == null)
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

            Story = await _context.Stories.FindAsync(id);

            if (Story != null)
            {
                _context.Stories.Remove(Story);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
