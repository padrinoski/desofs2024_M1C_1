using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DESOFT.Server.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Corrige_auditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "User_Role",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(7003),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "User_Role",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(7533),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(1567),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(2005),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "ShoppingCartItem",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(2245),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(8611),
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(9064),
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
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
                defaultValueSql: "getdate()",
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 89, DateTimeKind.Utc).AddTicks(5739),
                oldComment: "Data de alteração do registo (auditoria).");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "User_Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(7003),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()",
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "User_Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(7533),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()",
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(1567),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()",
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 100, DateTimeKind.Utc).AddTicks(2005),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()",
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "ShoppingCartItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(5754),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(8611),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()",
                oldComment: "Data de criação do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteracaoData",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 99, DateTimeKind.Utc).AddTicks(9064),
                comment: "Data de alteração do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()",
                oldComment: "Data de alteração do registo (auditoria).");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriacaoData",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 11, 9, 7, 90, DateTimeKind.Utc).AddTicks(7818),
                comment: "Data de criação do registo (auditoria).",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
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
                oldDefaultValueSql: "getdate()",
                oldComment: "Data de alteração do registo (auditoria).");
        }
    }
}
