using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities;
 
namespace Server.Infrastructure.Configurations
{
    internal sealed class ProductionConfiguration : IEntityTypeConfiguration<Production>
    {
        public void Configure(EntityTypeBuilder<Production> builder)
        {
            builder.Property(p => p.Quantity).HasColumnType("decimal(7,2)");
        }
    }
}
