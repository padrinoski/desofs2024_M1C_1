using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DESOFT.Server.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Order")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total Cost"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Address"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(7882), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(8205), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "ID of the ShoppingCart")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(2816), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(3143), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                });

            migrationBuilder.CreateTable(
                name: "ComicBook",
                columns: table => new
                {
                    ComicBookId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Comic Book.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Version"),
                    PublishingDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "Publishing Date"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Title"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Description"),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Author"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 35, DateTimeKind.Utc).AddTicks(9817), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(226), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicBook", x => x.ComicBookId);
                    table.ForeignKey(
                        name: "FK_ComicBook_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Inventory")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicBookId = table.Column<int>(type: "int", nullable: false, comment: "ID of the ComicBook"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(4934), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(5355), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_ComicBook_ComicBookId",
                        column: x => x.ComicBookId,
                        principalTable: "ComicBook",
                        principalColumn: "ComicBookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false, comment: "ID of the OrderItem")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Order"),
                    ComicBookId = table.Column<int>(type: "int", nullable: false, comment: "ID of the ComicBook"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 37, DateTimeKind.Utc).AddTicks(3750), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 37, DateTimeKind.Utc).AddTicks(4400), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_ComicBook_ComicBookId",
                        column: x => x.ComicBookId,
                        principalTable: "ComicBook",
                        principalColumn: "ComicBookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "int", nullable: false, comment: "ID of the ShoppingCartItem")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicBookId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Comic Book"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(6048), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(6494), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ComicBook_ComicBookId",
                        column: x => x.ComicBookId,
                        principalTable: "ComicBook",
                        principalColumn: "ComicBookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComicBook_OrderId",
                table: "ComicBook",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ComicBookId",
                table: "Inventory",
                column: "ComicBookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ComicBookId",
                table: "OrderItem",
                column: "ComicBookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ComicBookId",
                table: "ShoppingCartItem",
                column: "ComicBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "ComicBook");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
