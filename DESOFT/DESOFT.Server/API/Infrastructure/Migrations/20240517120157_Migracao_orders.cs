using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DESOFT.Server.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migracao_orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Payment Method");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "ID of the Shopping Cart");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShoppingCartId",
                table: "Order",
                column: "ShoppingCartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShoppingCart_ShoppingCartId",
                table: "Order",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Restrict);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShoppingCart_ShoppingCartId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShoppingCartId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false, comment: "ID of the OrderItem")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicBookId = table.Column<int>(type: "int", nullable: false, comment: "ID of the ComicBook"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Order"),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()", comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria)."),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()", comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity")
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

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ComicBookId",
                table: "OrderItem",
                column: "ComicBookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }
    }
}
