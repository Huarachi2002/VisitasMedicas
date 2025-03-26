using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppDB.Migrations
{
    /// <inheritdoc />
    public partial class AddModelsCategoriaPeriodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                schema: "ERP",
                table: "Cliente1");

            migrationBuilder.AddColumn<long>(
                name: "IdCategoria",
                schema: "ERP",
                table: "Cliente1",
                type: "bigint",
                maxLength: 15,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "ERP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                schema: "ERP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ERP",
                table: "Categoria",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1L, "4 veces x mes", "A" },
                    { 2L, "2 veces x mes", "B" },
                    { 3L, "1 vez x mes", "C" }
                });

            migrationBuilder.InsertData(
                schema: "ERP",
                table: "Periodo",
                columns: new[] { "Id", "FechaFin", "FechaInicio", "Nombre" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Enero" },
                    { 2L, new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Febrero" },
                    { 3L, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Marzo" },
                    { 4L, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Abril" },
                    { 5L, new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Mayo" },
                    { 6L, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Junio" },
                    { 7L, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Julio" },
                    { 8L, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Agosto" },
                    { 9L, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Septiembre" },
                    { 10L, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Octubre" },
                    { 11L, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Noviembre" },
                    { 12L, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "2024 - Diciembre" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente1_IdCategoria",
                schema: "ERP",
                table: "Cliente1",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente1_Categoria_IdCategoria",
                schema: "ERP",
                table: "Cliente1",
                column: "IdCategoria",
                principalSchema: "ERP",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente1_Categoria_IdCategoria",
                schema: "ERP",
                table: "Cliente1");

            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "ERP");

            migrationBuilder.DropTable(
                name: "Periodo",
                schema: "ERP");

            migrationBuilder.DropIndex(
                name: "IX_Cliente1_IdCategoria",
                schema: "ERP",
                table: "Cliente1");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                schema: "ERP",
                table: "Cliente1");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                schema: "ERP",
                table: "Cliente1",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
