

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersStories.Data.Entities;

namespace Securite.Data.Configurations
{
    public class StoryConfig : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.What).IsRequired();
            builder.Property(x => x.Why).IsRequired();
           
            builder.ToTable("Stories");
        }        
    }
}
