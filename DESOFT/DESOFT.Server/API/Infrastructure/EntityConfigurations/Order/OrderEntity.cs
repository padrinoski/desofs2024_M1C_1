using DESOFT.Server.API.Domain.Entities.Order;
using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            builder.Property(e => e.PaymentMethod)
                .HasConversion(new EnumToStringConverter<PaymentMethod>())
                .HasComment("Payment Method");

            builder.Property(e => e.ShoppingCartId)
                .HasComment("ID of the Shopping Cart");

            builder.HasOne(e => e.ShoppingCart)
                .WithOne(s => s.Order)
                .HasForeignKey<Domain.Entities.Order.Order>(e => e.ShoppingCartId);


            builder.AsAuditableEntity();
        }
    }
}