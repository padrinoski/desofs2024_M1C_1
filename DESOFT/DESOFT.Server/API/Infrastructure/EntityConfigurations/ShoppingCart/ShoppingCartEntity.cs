using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.ShoppingCart
{
    public class ShoppingCartEntity : IEntityTypeConfiguration<Domain.Entities.ShoppingCart.ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ShoppingCart.ShoppingCart> builder)
        {
            builder.ToTable(nameof(Domain.Entities.ShoppingCart.ShoppingCart));

            builder.HasKey(e => e.ShoppingCartId);

            builder.Property(e => e.ShoppingCartId)
                .HasComment("ID of the ShoppingCart");
                
            builder.Property(e => e.UserId)
                .HasComment("ID of the User");

            builder.HasOne(e => e.User)
                .WithOne(e => e.ShoppingCart)
                .HasForeignKey<Domain.Entities.ShoppingCart.ShoppingCart>(e => e.UserId);

            builder.AsAuditableEntity();
        }
    }
}
