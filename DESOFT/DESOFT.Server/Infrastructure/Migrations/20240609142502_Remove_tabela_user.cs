using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DESOFS.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_tabela_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_User_UserId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_User_UserId",
                table: "User_Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Role_UserId",
                table: "User_Role");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "User_Role",
                type: "nvarchar(max)",
                nullable: false,
                comment: "ID of the User",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID of the User");

            migrationBuilder.AlterColumn<string>(
                name: "CriacaoUtilizadorId",
                table: "User_Role",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "AlteracaoUtilizadorId",
                table: "User_Role",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "CriacaoUtilizadorId",
                table: "ShoppingCartItem",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "AlteracaoUtilizadorId",
                table: "ShoppingCartItem",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: false,
                comment: "ID of the User",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID of the User");

            migrationBuilder.AlterColumn<string>(
                name: "CriacaoUtilizadorId",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "AlteracaoUtilizadorId",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "CriacaoUtilizadorId",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "AlteracaoUtilizadorId",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "CriacaoUtilizadorId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "AlteracaoUtilizadorId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "CriacaoUtilizadorId",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "AlteracaoUtilizadorId",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "CriacaoUtilizadorId",
                table: "ComicBook",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<string>(
                name: "AlteracaoUtilizadorId",
                table: "ComicBook",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false, comment: "ID of the OrderItem")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Order"),
                    ComicBookId = table.Column<int>(type: "int", nullable: false, comment: "ID of the ComicBook"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()", comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()", comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "User_Role",
                type: "int",
                nullable: false,
                comment: "ID of the User",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ID of the User");

            migrationBuilder.AlterColumn<int>(
                name: "CriacaoUtilizadorId",
                table: "User_Role",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "AlteracaoUtilizadorId",
                table: "User_Role",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "CriacaoUtilizadorId",
                table: "ShoppingCartItem",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "AlteracaoUtilizadorId",
                table: "ShoppingCartItem",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                comment: "ID of the User",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ID of the User");

            migrationBuilder.AlterColumn<int>(
                name: "CriacaoUtilizadorId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "AlteracaoUtilizadorId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "CriacaoUtilizadorId",
                table: "Role",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "AlteracaoUtilizadorId",
                table: "Role",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "CriacaoUtilizadorId",
                table: "Order",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "AlteracaoUtilizadorId",
                table: "Order",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "CriacaoUtilizadorId",
                table: "Inventory",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "AlteracaoUtilizadorId",
                table: "Inventory",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "CriacaoUtilizadorId",
                table: "ComicBook",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que criou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que criou o registo (auditoria).");

            migrationBuilder.AlterColumn<int>(
                name: "AlteracaoUtilizadorId",
                table: "ComicBook",
                type: "int",
                nullable: false,
                comment: "Identificador do utilizador que alterou o registo (auditoria).",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Identificador do utilizador que alterou o registo (auditoria).");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "ID of the User")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Address"),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()", comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria)."),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()", comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Password"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Username")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_UserId",
                table: "User_Role",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_User_UserId",
                table: "ShoppingCart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_User_UserId",
                table: "User_Role",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
