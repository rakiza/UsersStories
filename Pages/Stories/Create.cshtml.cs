using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using UsersStories.Data;
using UsersStories.Data.Entities;
using UsersStories.Models;

namespace UsersStories.Pages.Stories
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
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public StoryModel Story { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var story = new Story();
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
       
        private SelectList PopulateActors(string selected=null)
        {
            var actors = _context.Actors.OrderBy(a => a.Name).ToList();
            return new SelectList(actors, "Id", "Name", selected);
        }

        private SelectList PopulateContexts(string selected = null)
        {
            var contexts = _context.Contexts.OrderBy(c => c.Order).ToList();
            return new SelectList(contexts, "Id", "Name", selected);
        }

        private int GetLastStoryOrder(string actorId=null)
        {
            if (_context.Stories.Any())
            {
                if(actorId!=null)
                    return _context.Stories.Where(s=>s.ActorId==actorId).Max(s => s.Order) + 1;

                return _context.Stories.Max(s => s.Order)+1;
            }
            return  1;
        }
        

        public PartialViewResult OnGetAddStory(string actorId=null)
        {
            StoryModel model = new StoryModel
            {
                Id = Guid.NewGuid().ToString(),
                ActorId = actorId,
                Contexts= PopulateContexts(),
                Actors= PopulateActors(),
                Order= GetLastStoryOrder(actorId),
                SysDate=DateTime.Now,
                Color="primary"
            };
            return new PartialViewResult
            {
                ViewName = "_StoryUI",
                ViewData = new ViewDataDictionary<StoryModel>(ViewData, model)
            };
        }

        public PartialViewResult OnGetEditStory(string id)
        {
            var story = _context.Stories
                .Include(s=>s.Actor)
                .FirstOrDefault(s => s.Id == id);

            StoryModel model = new();
            if (story != null)
            {
                model = new StoryModel
                {
                    Id = story.Id,
                    ActorId=story.ActorId,
                    ContextId=story.ContextId,
                    What=story.What,
                    Why=story.Why,                    
                    Actors = PopulateActors(story.ActorId),
                    Contexts = PopulateContexts(story.ContextId),
                    Order = story.Order,
                    SysDate = story.SysDate,
                    Editing=true,
                    Color=story.Actor.Color,
                };
            }

            return new PartialViewResult
            {
                ViewName = "_StoryUI",
                ViewData = new ViewDataDictionary<StoryModel>(ViewData, model)
            };
        }

        public PartialViewResult OnPostEditStory(StoryModel model)
        {
            if (ModelState.IsValid)
            {
                var story = _context.Stories.FirstOrDefault(s=>s.Id==model.Id);
                if (story != null)
                {
                    story.ActorId = model.ActorId;
                    story.ContextId = model.ContextId;
                    story.What = model.What;
                    story.Why = model.Why;
                    story.Order = model.Order;                   
                }               

                _context.Stories.Update(story);
                _context.SaveChanges();

                var actor = _context.Actors.FirstOrDefault(a => a.Id == story.ActorId);
                var context = _context.Contexts.FirstOrDefault(c => c.Id == story.ContextId);
                var storyItemModel = new StoryItemModel
                {
                    Id = story.Id,
                    ActorId = actor.Id,
                    Actor = actor.Name,
                    ActorColor = actor.Color,
                    Context = context?.Name,
                    ContextId = context?.Id,
                    What = story.What,
                    Why = story.Why,
                    Order = story.Order,
                    Validated = story.Validated,
                    SysDate = story.SysDate,
                    AfterEditing=true,
                };
                return new PartialViewResult
                {
                    ViewName = "_Story",
                    ViewData = new ViewDataDictionary<StoryItemModel>(ViewData, storyItemModel)
                };
            }
            else
            {
                StoryModel storyModel = new StoryModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Actors = PopulateActors(),
                    Order = GetLastStoryOrder(),
                    SysDate = DateTime.Now,
                };
                return new PartialViewResult
                {
                    ViewName = "_StoryUI",
                    ViewData = new ViewDataDictionary<StoryModel>(ViewData, storyModel)
                };
            }

        }

        public PartialViewResult OnGetCancelEditStory(string id)
        {
            var story = _context.Stories.FirstOrDefault(s => s.Id == id);
            var actor = _context.Actors.FirstOrDefault(a => a.Id == story.ActorId);
            var context = _context.Contexts.FirstOrDefault(c => c.Id == story.ContextId);
            var storyItemModel = new StoryItemModel
            {
                Id = story.Id,
                ActorId = actor.Id,
                Actor = actor.Name,
                ActorColor = actor.Color,
                Context=context?.Name,
                ContextId=context?.Id,
                What = story.What,
                Why = story.Why,
                Order = story.Order,
                Validated = story.Validated,
                SysDate = story.SysDate,
                AfterEditing = true,
            };
            return new PartialViewResult
            {
                ViewName = "_Story",
                ViewData = new ViewDataDictionary<StoryItemModel>(ViewData, storyItemModel)
            };

        }

        public PartialViewResult OnGetCloneStory(string id)
        {
            var story = _context.Stories.FirstOrDefault(s => s.Id == id);
            var newStory = new Story
            {
                Id=Guid.NewGuid().ToString(),
                ActorId=story.ActorId,
                ContextId=story.ContextId,
                What=story.What,
                Why=story.Why,
                Order=GetLastStoryOrder(),
                Validated=story.Validated,
                SysDate=DateTime.Now,
            };

            _context.Stories.Add(newStory);
            _context.SaveChanges();

            var actor = _context.Actors.FirstOrDefault(a => a.Id == story.ActorId);
            var context = _context.Contexts.FirstOrDefault(c => c.Id == story.ContextId);
            var storyItemModel = new StoryItemModel
            {
                Id = newStory.Id,
                ActorId = actor.Id,
                Actor = actor.Name,
                ActorColor = actor.Color,
                Context = context?.Name,
                ContextId = context?.Id,
                What = newStory.What,
                Why = newStory.Why,
                Order = newStory.Order,
                Validated = newStory.Validated,
                SysDate = newStory.SysDate,                
            };
            return new PartialViewResult
            {
                ViewName = "_Story",
                ViewData = new ViewDataDictionary<StoryItemModel>(ViewData, storyItemModel)
            };

        }

        public JsonResult OnGetActorColor(string id)
        {
            var actor = _context.Actors.FirstOrDefault(a => a.Id == id);
            if (actor != null)
            {                
                return new JsonResult(new { color = actor.Color });
            }
            return new JsonResult(new { color = "primary" });
        }

        public PartialViewResult OnPostCreateStory(StoryModel model)
        {
            if (ModelState.IsValid)
            {
                Story story = new Story
                {
                    Id = model.Id,
                    ActorId = model.ActorId,
                    ContextId=model.ContextId,
                    What = model.What,
                    Why = model.Why,
                    Order = model.Order,
                    SysDate = DateTime.Now,
                };

                _context.Stories.Add(story);
                _context.SaveChanges();

                var actor = _context.Actors.FirstOrDefault(a => a.Id == story.ActorId);
                var context = _context.Contexts.FirstOrDefault(c => c.Id == story.ContextId);

                var storyItemModel = new StoryItemModel
                {
                    Id = story.Id,
                    ActorId = actor.Id,
                    Actor = actor.Name,
                    ActorColor = actor.Color,
                    Context = context?.Name,
                    ContextId = context?.Id,
                    What = story.What,
                    Why = story.Why,
                    Order = story.Order,
                    Validated = story.Validated,
                    SysDate = story.SysDate,
                };
                return new PartialViewResult
                {
                    ViewName = "_Story",
                    ViewData = new ViewDataDictionary<StoryItemModel>(ViewData, storyItemModel)
                };
            }
            else
            {
                StoryModel storyModel = new StoryModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Actors = PopulateActors(),
                    Contexts=PopulateContexts(),
                    Order = GetLastStoryOrder(),
                    SysDate = DateTime.Now,
                };
                return new PartialViewResult
                {
                    ViewName = "_StoryUI",
                    ViewData = new ViewDataDictionary<StoryModel>(ViewData, storyModel)
                };
            }
            
        }

        public JsonResult OnGetDeleteStory(string id)
        {
            var story = _context.Stories.FirstOrDefault(s => s.Id == id);
            if (story != null)
            {
                _context.Stories.Remove(story);
                _context.SaveChanges();
            }
            return new JsonResult(new { hasError = false });
        }
    }
}
