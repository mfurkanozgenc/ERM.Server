using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities;

namespace Server.Infrastructure.Configurations
{
    public sealed class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasOne(p => p.Product).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
