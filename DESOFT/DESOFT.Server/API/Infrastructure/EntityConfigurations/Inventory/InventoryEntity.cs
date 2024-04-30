using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DESOFT.Server.API.Infrastructure.Extensions;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.Inventory
{
    public class InventoryEntity : IEntityTypeConfiguration<Domain.Entities.Inventory.Inventory>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Inventory.Inventory> builder)
        {
            builder.ToTable(nameof(Domain.Entities.Inventory.Inventory));

            builder.HasKey(e => e.InventoryId);

            builder.Property(e => e.InventoryId)
                .HasComment("ID of the Inventory");

            builder.Property(e => e.ComicBookId)
                .HasComment("ID of the ComicBook");

            builder.HasOne(e => e.ComicBook)
                .WithMany(e => e.Inventory)
                .HasForeignKey(e => e.ComicBookId);

            builder.Property(e => e.Quantity)
                .HasComment("Quantity");

            builder.AsAuditableEntity();
        }
    }
}
