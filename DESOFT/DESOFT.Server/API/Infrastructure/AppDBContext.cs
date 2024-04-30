using DESOFT.Server.API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DESOFT.Server.API.Infrastructure
{
    public class AppDBContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppDBContext(DbContextOptions<AppDBContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            Database.SetCommandTimeout(150000);
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Initialize Entities

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #endregion Initialize Entities

            #region Remove Cascade Delete

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #endregion Remove Cascade Delete
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            PopulateAuditFields();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            PopulateAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            PopulateAuditFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            PopulateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void PopulateAuditFields()
        {
            var currentDateTime = DateTime.UtcNow;
            int currentUserId = 1;

            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is IAuditableEntity))
            {
                var actualItem = (AuditableEntity)item.Entity;
                actualItem.CriacaoData = currentDateTime;
                actualItem.CriacaoUtilizadorId = currentUserId;
                actualItem.AlteracaoData = currentDateTime;
                actualItem.AlteracaoUtilizadorId = currentUserId;
            }

            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is IPartialAuditableEntity && !(e.Entity is IAuditableEntity)))
            {
                var actualItem = (PartialAuditableEntity)item.Entity;
                actualItem.CriacaoData = currentDateTime;
                actualItem.CriacaoUtilizadorId = currentUserId;
            }

            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified && e.Entity is IAuditableEntity))
            {
                var actualItem = (AuditableEntity)item.Entity;
                Entry(actualItem).Property(p => p.CriacaoData).IsModified = false;
                Entry(actualItem).Property(p => p.CriacaoUtilizadorId).IsModified = false;
                actualItem.AlteracaoData = currentDateTime;
                actualItem.AlteracaoUtilizadorId = currentUserId;
            }
        }
    }
}
