using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities;

namespace Server.Infrastructure.Configurations
{
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.TaxNumber).HasColumnType("varchar(11)");
        }
    }
}
