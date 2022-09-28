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

namespace UsersStories.Pages.Stories
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UsersStories.Data.ApplicationDbContext _context;

        public IndexModel(UsersStories.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public StoryFilterModel Filter { get; set; }
        public IList<StoryItemModel> Stories { get;set; }

        public async Task OnGetAsync(StoryFilterModel filter)
        {
            filter.Actors = PopulateActors(filter.ActorId);
            filter.Contexts = PopulateContexts(filter.ContextId);
            Filter = filter;

            var _stories = await _context.Stories
                .Include(s => s.Actor)
                .Include(s => s.Context)
                .OrderBy(s=>s.Actor.Name).OrderBy(s=>s.Order)
                .ToListAsync();

            if (filter.ActorId != null)
                _stories = _stories.Where(s => s.ActorId == filter.ActorId).ToList();

            if (filter.ContextId != null)
                _stories = _stories.Where(s => s.ContextId == filter.ContextId).ToList();


            if (filter.Word!=null)
                _stories = _stories.Where(s => s.What.Contains(filter.Word) | s.Why.Contains(filter.Word)).ToList();

            Stories = (from story in _stories
                       select new StoryItemModel
                       {
                           Id=story.Id,
                           ActorId=story.ActorId,
                           Actor=story.Actor.Name,
                           ActorColor=story.Actor.Color,
                           Context=story.Context?.Name,
                           ContextId=story.ContextId,
                           What=story.What,
                           Why=story.Why,
                           Order=story.Order,
                           Validated=story.Validated,
                           SysDate=story.SysDate,
                       }).ToList();
        }

        private SelectList PopulateActors(string actorId)
        {
            return new SelectList(_context.Actors.OrderBy(a => a.Name).ToList(), "Id", "Name", actorId);
        }

        private SelectList PopulateContexts(string actorId)
        {
            return new SelectList(_context.Contexts.OrderBy(a => a.Name).ToList(), "Id", "Name", actorId);
        }
    }
}
