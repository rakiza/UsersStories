using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Securite.Data.Configurations;
using UsersStories.Data.Entities;

namespace UsersStories.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ActorConfig());
            builder.ApplyConfiguration(new StoryConfig());
            builder.ApplyConfiguration(new ContextConfig());
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Context> Contexts { get; set; }

    }
}
