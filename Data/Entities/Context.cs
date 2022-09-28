using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersStories.Data.Entities
{
    public class Context
    {
        public string Id { get; set; }

        [Display(Name = "Désignation")]
        public string Name { get; set; }

        [Display(Name = "Ordre d'affichage")]
        public int Order { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}
