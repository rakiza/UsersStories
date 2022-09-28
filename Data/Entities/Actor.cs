using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersStories.Data.Entities
{
    public class Actor
    {
        public string Id { get; set; }
        [Display(Name="Nom de l'acteur")]
        public string Name { get; set; }

        [Display(Name = "Couleur")]
        public string Color { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}
