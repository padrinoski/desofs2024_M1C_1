using DESOFT.Server.API.Domain.Entities.Order;
using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.Order
{
    public class OrderItemEntity : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable(nameof(OrderItem));

            builder.HasKey(e => e.OrderItemId);

            builder.Property(e => e.OrderItemId)
                .HasComment("ID of the OrderItem");
            
            builder.Property(e => e.OrderId)
                .HasComment("ID of the Order");

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.OrderId);
            
            builder.Property(e => e.ComicBookId)
                .HasComment("ID of the ComicBook");

            builder.HasOne(e => e.ComicBook)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.ComicBookId);

            builder.Property(e => e.Quantity)
                .HasComment("Quantity");

            builder.AsAuditableEntity();
        }
    }
}
