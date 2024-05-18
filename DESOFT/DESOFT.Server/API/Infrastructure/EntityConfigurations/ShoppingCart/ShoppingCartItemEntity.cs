using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.ShoppingCart
{
    public class ShoppingCartItemEntity : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable(nameof(ShoppingCartItem));

            builder.HasKey(e => e.ShoppingCartItemId);

            builder.Property(e => e.ShoppingCartItemId)
                .HasComment("ID of the ShoppingCartItem");

            builder.Property(e => e.ComicBookId)
                .HasComment("ID of the Comic Book");
    
            builder.HasOne(e => e.ComicBook)
                .WithMany(e => e.ShoppingCartItem)
                .HasForeignKey(e => e.ComicBookId);

            builder.Property(e => e.ShoppingCartId)
                .HasComment("ID of the Shopping Cart");

            builder.HasOne(e => e.ShoppingCart)
                .WithMany(e => e.ShoppingCartItem)
                .HasForeignKey(e => e.ShoppingCartId);

            builder.AsAuditableEntity();
        }
    }
}
