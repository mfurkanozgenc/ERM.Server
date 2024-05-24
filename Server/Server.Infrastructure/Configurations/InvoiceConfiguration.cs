using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Infrastructure.Configurations
{
    internal sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(p => p.Type)
                   .HasConversion(type => type.Value, value => InvoiceTypeEnum.FromValue(value));
        }
    }
}
