

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersStories.Data.Entities;

namespace Securite.Data.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(120);
            builder.HasMany(x => x.Stories)
                .WithOne(w => w.Actor)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Actors");
        }        
    }
}
