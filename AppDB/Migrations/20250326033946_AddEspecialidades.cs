using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppDB.Migrations
{
    /// <inheritdoc />
    public partial class AddEspecialidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidad",
                schema: "ERP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoEspecialidad",
                schema: "ERP",
                columns: table => new
                {
                    IdEmpleado = table.Column<long>(type: "bigint", nullable: false),
                    IdEspecialidad = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoEspecialidad", x => new { x.IdEmpleado, x.IdEspecialidad });
                    table.ForeignKey(
                        name: "FK_EmpleadoEspecialidad_Empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalSchema: "ERP",
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoEspecialidad_Especialidad_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalSchema: "ERP",
                        principalTable: "Especialidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "ERP",
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Estado", "FechaRegistro" },
                values: new object[] { 2, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                schema: "ERP",
                table: "Especialidad",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1L, "CAR - CARDIOLOGIA" },
                    { 2L, "CIR - CIRUGIA" },
                    { 3L, "GIN - GINECOLOGIA" },
                    { 4L, "MGE - MEDICINA GENERAL" },
                    { 5L, "MIN - MEDICINA INTERNA" },
                    { 6L, "ODO - ODONTOLOGIA" },
                    { 7L, "PED - PEDIATRIA" },
                    { 8L, "TRA - TRAUMATOLOGIA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoEspecialidad_IdEspecialidad",
                schema: "ERP",
                table: "EmpleadoEspecialidad",
                column: "IdEspecialidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoEspecialidad",
                schema: "ERP");

            migrationBuilder.DropTable(
                name: "Especialidad",
                schema: "ERP");

            migrationBuilder.DeleteData(
                schema: "SIS",
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "SIS",
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "SIS",
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "ERP",
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "ERP",
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "SIS",
                table: "TipoUsuario",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "SIS",
                table: "TipoUsuario",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                schema: "ERP",
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Estado", "FechaRegistro" },
                values: new object[] { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
