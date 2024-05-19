using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Infrastructure.Configurations
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Type)
                .HasConversion(type => type.Value , value => ProductTypeEnum.FromValue(value));
        }
    }
}
