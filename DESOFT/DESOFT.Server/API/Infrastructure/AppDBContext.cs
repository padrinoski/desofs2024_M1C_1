﻿using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Domain.Entities.Common;
using DESOFT.Server.API.Domain.Entities.Order;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using DESOFT.Server.API.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query;

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
            string currentUserId = "1";

            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            string accessToken = string.Empty;

            if (!authorizationHeader.IsNullOrEmpty() || authorizationHeader.ToString().StartsWith("Bearer"))
            {
                accessToken = authorizationHeader.ToString().Substring("Bearer ".Length).Trim();

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(accessToken);
                var tokenS = jsonToken as JwtSecurityToken;

                if (tokenS.Payload.ContainsKey("userId"))
                {
                    tokenS.Payload.TryGetValue("userId", out var userId);
                    currentUserId = userId.ToString();
                }
                else if (tokenS.Payload.ContainsKey("sub"))
                {
                    tokenS.Payload.TryGetValue("sub", out var userId);
                    currentUserId = userId.ToString();
                }
            }

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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Role> UserRoles { get; set; }
        public virtual DbSet<ComicBook> ComicBook { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
