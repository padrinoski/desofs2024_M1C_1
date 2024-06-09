using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DESOFS.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Recria_tabela_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "User_Role",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    comment: "ID of the User",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldComment: "ID of the User");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "ShoppingCart",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    comment: "ID of the User",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldComment: "ID of the User");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "ID of the User"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Username"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Password"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Address"),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()", comment: "Data de criação do registo (auditoria)."),
                    CriacaoUtilizadorId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Identificador do utilizador que criou o registo (auditoria)."),
                    AlteracaoData = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()", comment: "Data de alteração do registo (auditoria)."),
                    AlteracaoUtilizadorId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Identificador do utilizador que alterou o registo (auditoria).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_User_Role_UserId",
            //    table: "User_Role",
            //    column: "UserId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShoppingCart_UserId",
            //    table: "ShoppingCart",
            //    column: "UserId",
            //    unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShoppingCart_User_UserId",
            //    table: "ShoppingCart",
            //    column: "UserId",
            //    principalTable: "User",
            //    principalColumn: "UserId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_User_Role_User_UserId",
            //    table: "User_Role",
            //    column: "UserId",
            //    principalTable: "User",
            //    principalColumn: "UserId",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "ID of the User");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: false,
                comment: "ID of the User",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "ID of the User");
        }
    }
}
