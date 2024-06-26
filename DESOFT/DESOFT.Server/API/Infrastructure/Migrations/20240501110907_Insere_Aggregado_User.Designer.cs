﻿// <auto-generated />
using System;
using DESOFT.Server.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DESOFT.Server.API.Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240501110907_Insere_Aggregado_User")]
    partial class Insere_Aggregado_User
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook", b =>
                {
                    b.Property<int>("ComicBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the Comic Book.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComicBookId"));

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(5739))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Author");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(5114))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Description");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price");

                    b.Property<DateOnly>("PublishingDate")
                        .HasColumnType("date")
                        .HasComment("Publishing Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Title");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Version");

                    b.HasKey("ComicBookId");

                    b.HasIndex("OrderId");

                    b.ToTable("ComicBook", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.Inventory.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the Inventory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(153))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<int>("ComicBookId")
                        .HasColumnType("int")
                        .HasComment("ID of the ComicBook");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(9666))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Quantity");

                    b.HasKey("InventoryId");

                    b.HasIndex("ComicBookId");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.Order.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the Order");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Address");

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(3155))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(2692))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Total Cost");

                    b.HasKey("OrderId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.Order.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the OrderItem");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(8406))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<int>("ComicBookId")
                        .HasColumnType("int")
                        .HasComment("ID of the ComicBook");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(7818))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasComment("ID of the Order");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Quantity");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ComicBookId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.ShoppingCart.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the ShoppingCart");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartId"));

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(2245))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(1724))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasComment("ID of the User");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ShoppingCart", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.ShoppingCart.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the ShoppingCartItem");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartItemId"));

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(6242))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<int>("ComicBookId")
                        .HasColumnType("int")
                        .HasComment("ID of the Comic Book");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(5754))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ComicBookId");

                    b.ToTable("ShoppingCartItem", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.User.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the Role");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(9064))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(8611))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("ID of the User");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the User");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Address");

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(2005))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(1567))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Username");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.User.User_Role", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID of the UserRole");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<DateTime>("AlteracaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(7533))
                        .HasComment("Data de alteração do registo (auditoria).");

                    b.Property<int>("AlteracaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que alterou o registo (auditoria).");

                    b.Property<DateTime>("CriacaoData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(7003))
                        .HasComment("Data de criação do registo (auditoria).");

                    b.Property<int>("CriacaoUtilizadorId")
                        .HasColumnType("int")
                        .HasComment("Identificador do utilizador que criou o registo (auditoria).");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasComment("ID of the Role");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasComment("ID of the User");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("User_Role", (string)null);
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook", b =>
                {
                    b.HasOne("DESOFT.Server.API.Domain.Entities.Order.Order", null)
                        .WithMany("ComicBook")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.Inventory.Inventory", b =>
                {
                    b.HasOne("DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook", "ComicBook")
                        .WithMany("Inventory")
                        .HasForeignKey("ComicBookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ComicBook");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.Order.OrderItem", b =>
                {
                    b.HasOne("DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook", "ComicBook")
                        .WithMany("OrderItems")
                        .HasForeignKey("ComicBookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DESOFT.Server.API.Domain.Entities.Order.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ComicBook");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.ShoppingCart.ShoppingCart", b =>
                {
                    b.HasOne("DESOFT.Server.API.Domain.Entities.User.User", "User")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("DESOFT.Server.API.Domain.Entities.ShoppingCart.ShoppingCart", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.ShoppingCart.ShoppingCartItem", b =>
                {
                    b.HasOne("DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook", "ComicBook")
                        .WithMany("ShoppingCartItem")
                        .HasForeignKey("ComicBookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ComicBook");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.User.User_Role", b =>
                {
                    b.HasOne("DESOFT.Server.API.Domain.Entities.User.Role", "Role")
                        .WithMany("User_Role")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DESOFT.Server.API.Domain.Entities.User.User", "User")
                        .WithOne("Role")
                        .HasForeignKey("DESOFT.Server.API.Domain.Entities.User.User_Role", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("OrderItems");

                    b.Navigation("ShoppingCartItem");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.Order.Order", b =>
                {
                    b.Navigation("ComicBook");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.User.Role", b =>
                {
                    b.Navigation("User_Role");
                });

            modelBuilder.Entity("DESOFT.Server.API.Domain.Entities.User.User", b =>
                {
                    b.Navigation("Role")
                        .IsRequired();

                    b.Navigation("ShoppingCart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
