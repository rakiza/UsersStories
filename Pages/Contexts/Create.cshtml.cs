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

namespace UsersStories.Pages.Contexts
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
            return Page();
        }

        [BindProperty]
        public Context Context { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Context.Id = Guid.NewGuid().ToString();
            _context.Contexts.Add(Context);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
