using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersStories.Models
{
    public class ActorModel
    {
        public ActorModel()
        {
            InitColors();
        }

        public void InitColors()
        {
            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text="primary",Value="primary"},
                new SelectListItem{Text="secondary",Value="secondary"},
                new SelectListItem{Text="success",Value="success"},
                new SelectListItem{Text="danger",Value="danger"},
                new SelectListItem{Text="warning",Value="warning"},
                new SelectListItem{Text="info",Value="info"},
                new SelectListItem{Text="dark",Value="dark"},
            };
            Colors = new SelectList(items, "Value", "Text", Color);
        }

        public string Id { get; set; }

        [Display(Name = "Nom de l'acteur")]
        public string Name { get; set; }

        [Display(Name = "Couleur")]
        public string Color { get; set; }
        public SelectList Colors { get; set; }
    }
}
