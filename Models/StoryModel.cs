using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersStories.Models
{
    public class StoryModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Acteur")]
        public string ActorId { get; set; }
        public SelectList Actors { get; set; }

        [Display(Name = "Context")]
        public string ContextId { get; set; }
        public SelectList Contexts { get; set; }

        [Required]
        [Display(Name = "Quoi?")]
        public string What { get; set; }

        [Required]
        [Display(Name = "Pourquoi?")]
        public string Why { get; set; }

        [Display(Name = "Ordre d'affichage")]
        public int Order { get; set; }

        [Display(Name = "Validé")]
        public bool Validated { get; set; }

        [Display(Name = "Date")]
        public DateTime SysDate { get; set; }

        public string Color { get; set; } = "primary";
        public bool Editing { get; set; } = false;
    }

    public class StoryItemModel
    {
        public string Id { get; set; }   
        
        public string ActorId { get; set; }
        public string Actor { get; set; }
        public string ActorColor { get; set; }        

        public string ContextId { get; set; }
        public string Context { get; set; }

        public string What { get; set; }        
        public string Why { get; set; }
        public int Order { get; set; }
        public bool Validated { get; set; }
        public DateTime SysDate { get; set; }
        public bool AfterEditing { get; set; }
    }

    public class StoryFilterModel
    {
        [Display(Name = "Acteur")]
        public string ActorId { get; set; }
        public SelectList Actors { get; set; }

        public string ContextId { get; set; }
        public SelectList Contexts { get; set; }

        [Display(Name = "Mot clé")]
        public string Word { get; set; }
    }
}
