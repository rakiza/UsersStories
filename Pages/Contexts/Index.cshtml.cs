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
using UsersStories.Models;

namespace UsersStories.Pages.Contexts
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UsersStories.Data.ApplicationDbContext _context;

        public IndexModel(UsersStories.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ContextModel> Contexts { get;set; }

        public async Task OnGetAsync()
        {
            var _contexts = await _context.Contexts.OrderBy(c=>c.Order).ToListAsync();
            Contexts = (from context in _contexts
                        select new ContextModel
                        {
                            Id=context.Id,
                            Name=context.Name,
                            Order=context.Order,
                        }).ToList();
        }
    }
}
