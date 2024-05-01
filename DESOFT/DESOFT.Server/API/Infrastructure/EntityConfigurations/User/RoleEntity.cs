using DESOFT.Server.API.Domain.Entities.User;
using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.User
{
    public class RoleEntity : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.HasKey(e => e.RoleId);

            builder.Property(e => e.RoleId)
                .HasComment("ID of the Role");

            builder.Property(e => e.RoleName)
                .HasComment("ID of the User");

            builder.AsAuditableEntity();
        }
    }
}
