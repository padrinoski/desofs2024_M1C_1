using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.ComicBooks;

public class ComicBookEntity : IEntityTypeConfiguration<ComicBook>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ComicBook> builder)
    {
        builder.ToTable(nameof(ComicBook));

        builder.HasKey(e => e.ComicBookId);

        builder.Property(e => e.ComicBookId)
            .HasComment("ID of the Comic Book.");
        
        builder.Property(e => e.Version)
            .HasComment("Version");
        
        builder.Property(e => e.PublishingDate)
            .HasComment("Publishing Date");
        
        builder.Property(e => e.Price)
            .HasColumnType("decimal(18,2)")
            .HasComment("Price");
        
        builder.Property(e => e.Title)
            .HasMaxLength(50)
            .HasComment("Title");
        
        builder.Property(e => e.Description)
            .HasMaxLength(200)
            .HasComment("Description");
        
        builder.Property(e => e.Author)
            .HasMaxLength(50)
            .HasComment("Author");

        builder.AsAuditableEntity();
    }
}
