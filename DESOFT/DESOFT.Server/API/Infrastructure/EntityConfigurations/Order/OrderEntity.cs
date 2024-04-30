using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.Order
{
    public class OrderEntity : IEntityTypeConfiguration<Domain.Entities.Order.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Order.Order> builder)
        {
            builder.ToTable(nameof(Domain.Entities.Order.Order));

            builder.HasKey(e => e.OrderId);

            builder.Property(e => e.OrderId)
                .HasComment("ID of the Order");

            builder.Property(e => e.TotalCost)
                .HasColumnType("decimal(18,2)")
                .HasComment("Total Cost");

            builder.Property(e => e.Address)
                .HasComment("Address");

            builder.AsAuditableEntity();
        }
    }
}
