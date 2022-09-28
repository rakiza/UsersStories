using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersStories.Data.Entities
{
    public class Story
    {
        public string Id { get; set; }        
        public string ActorId { get; set; }
        public string ContextId { get; set; }

        //public string WhatPrefix { get; set; }
        public string What { get; set; }

        //public string WhyPrefix { get; set; }
        public string Why { get; set; }

        public int Order { get; set; }
        public bool Validated { get; set; }
        public DateTime SysDate { get; set; }

        public Actor Actor { get; set; }
        public Context Context { get; set; }
    }
}
