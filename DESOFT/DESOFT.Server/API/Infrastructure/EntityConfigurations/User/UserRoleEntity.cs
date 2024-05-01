using DESOFT.Server.API.Domain.Entities.User;
using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.User
{
    public class UserRoleEntity : IEntityTypeConfiguration<User_Role>
    {
        public void Configure(EntityTypeBuilder<User_Role> builder)
        {
            builder.ToTable(nameof(User_Role));

            builder.HasKey(e => e.UserRoleId);

            builder.Property(e => e.UserRoleId)
                .HasComment("ID of the UserRole");
            
            builder.Property(e => e.UserId)
                .HasComment("ID of the User");
            
            builder.HasOne(e => e.User)
                .WithOne(e => e.Role)
                .HasForeignKey<User_Role>(e => e.UserId);
            
            builder.Property(e => e.RoleId)
                .HasComment("ID of the Role");
            
            builder.HasOne(e => e.Role)
                .WithMany(e => e.User_Role)
                .HasForeignKey(e => e.RoleId);

            builder.AsAuditableEntity();
        }
    }
}
