using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DESOFT.Server.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Insere_Aggregado_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "ShoppingCartItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(5754),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(6048),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "ShoppingCartItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(6242),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(6494),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "ShoppingCart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(1724),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(2816),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "ShoppingCart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(2245),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(3143),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "ID of the User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(7818),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 37, DateTimeKind.Utc).AddTicks(3750),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(8406),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 37, DateTimeKind.Utc).AddTicks(4400),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(2692),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(7882),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(3155),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(8205),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(9666),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(4934),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(153),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(5355),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "ComicBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(5114),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 35, DateTimeKind.Utc).AddTicks(9817),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "ComicBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(5739),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(226),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Role")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "ID of the User"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(8611), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(9064), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "ID of the User")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Username"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Password"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Address"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(1567), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(2005), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "User_Role",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false, comment: "ID of the UserRole")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false, comment: "ID of the Role"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "ID of the User"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(7003), comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(7533), comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_User_Role_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_RoleId",
                table: "User_Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_UserId",
                table: "User_Role",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_User_UserId",
                table: "ShoppingCart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_User_UserId",
                table: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "User_Role");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCart");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "ShoppingCartItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(6048),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(5754),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "ShoppingCartItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(6494),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(6242),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "ShoppingCart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(2816),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(1724),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "ShoppingCart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 38, DateTimeKind.Utc).AddTicks(3143),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(2245),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 37, DateTimeKind.Utc).AddTicks(3750),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(7818),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 37, DateTimeKind.Utc).AddTicks(4400),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(8406),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(7882),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(2692),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(8205),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(3155),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(4934),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(9666),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(5355),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(153),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "ComicBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 35, DateTimeKind.Utc).AddTicks(9817),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(5114),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "ComicBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 34, 25, 36, DateTimeKind.Utc).AddTicks(226),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(5739),
                oldComment: "Data de alteração do registo (auditoria).");
        }
    }
}
