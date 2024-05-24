using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities;

namespace Server.Infrastructure.Configurations
{
    internal sealed class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasOne(p => p.Product).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.Price).HasColumnType("money");
            builder.Property(p => p.Quantity).HasColumnType("decimal(7,2)");
        }
    }
}
