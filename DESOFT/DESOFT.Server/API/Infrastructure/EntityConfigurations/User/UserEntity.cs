using DESOFT.Server.API.Domain.Entities.User;
using DESOFT.Server.API.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DESOFT.Server.API.Infrastructure.EntityConfigurations.User
{
    public class UserEntity : IEntityTypeConfiguration<Domain.Entities.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.User.User> builder)
        {
            builder.ToTable(nameof(Domain.Entities.User.User));

            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                .HasComment("ID of the User");

            builder.Property(e => e.UserName)
                .HasComment("Username");

            builder.Property(e => e.Address)
                .HasComment("Address");

            builder.Property(e => e.Password)
                .HasComment("Password");

            builder.AsAuditableEntity();
        }
    }
}
