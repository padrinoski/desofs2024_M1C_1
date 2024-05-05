using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DESOFT.Server.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Corrige_modelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicBook_Order_OrderId",
                table: "ComicBook");

            migrationBuilder.DropIndex(
                name: "IX_ComicBook_OrderId",
                table: "ComicBook");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ComicBook");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishingDate",
                table: "ComicBook",
                type: "datetime2",
                nullable: false,
                comment: "Publishing Date",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComment: "Publishing Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "PublishingDate",
                table: "ComicBook",
                type: "date",
                nullable: false,
                comment: "Publishing Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Publishing Date");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ComicBook",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComicBook_OrderId",
                table: "ComicBook",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicBook_Order_OrderId",
                table: "ComicBook",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");
        }
    }
}
