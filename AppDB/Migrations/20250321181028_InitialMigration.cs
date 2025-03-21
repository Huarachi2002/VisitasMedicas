using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ERP");

            migrationBuilder.EnsureSchema(
                name: "NIV");

            migrationBuilder.EnsureSchema(
                name: "GEN");

            migrationBuilder.EnsureSchema(
                name: "SIS");

            migrationBuilder.CreateTable(
                name: "Regional",
                schema: "NIV",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                schema: "SIS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoERP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Abreviatura = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente1",
                schema: "ERP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReferenciaUbicacion = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Foto = table.Column<string>(type: "text", nullable: true),
                    Barrio = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Lote = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    UV = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Manzana = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    NroCasa = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Especialidad1 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Especialidad2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Especialidad3 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Categoria = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Dias = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Turno = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdRegional = table.Column<long>(type: "bigint", nullable: false),
                    Movil = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente1_Regional_IdRegional",
                        column: x => x.IdRegional,
                        principalSchema: "NIV",
                        principalTable: "Regional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                schema: "GEN",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoERP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Registro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IdDepartamento = table.Column<long>(type: "bigint", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    IdEmpresa = table.Column<long>(type: "bigint", nullable: false),
                    IdRegion = table.Column<long>(type: "bigint", nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: true),
                    Latitud = table.Column<decimal>(type: "numeric", nullable: true),
                    Longitud = table.Column<decimal>(type: "numeric", nullable: true),
                    Lugar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ZonaFranca = table.Column<int>(type: "integer", nullable: true),
                    IdRegional = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sucursal_Regional_IdRegional",
                        column: x => x.IdRegional,
                        principalSchema: "NIV",
                        principalTable: "Regional",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "ERP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoERP = table.Column<string>(type: "text", nullable: true),
                    Ci = table.Column<string>(type: "text", nullable: true),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Paterno = table.Column<string>(type: "text", nullable: true),
                    Materno = table.Column<string>(type: "text", nullable: true),
                    Nit = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    LimiteCredito = table.Column<decimal>(type: "numeric", nullable: false),
                    SaldoDeudor = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitud = table.Column<decimal>(type: "numeric", nullable: false),
                    Latitud = table.Column<decimal>(type: "numeric", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    IdListaPrecio = table.Column<long>(type: "bigint", nullable: true),
                    IdPorcentajeDescuento = table.Column<long>(type: "bigint", nullable: true),
                    IdNivelC1 = table.Column<long>(type: "bigint", nullable: false),
                    IdSucursal = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoCliente = table.Column<long>(type: "bigint", nullable: true),
                    Transaccion = table.Column<string>(type: "text", nullable: true),
                    HashCode = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    IdTabla = table.Column<long>(type: "bigint", nullable: true),
                    IdCliente1 = table.Column<long>(type: "bigint", nullable: true),
                    Visitado = table.Column<int>(type: "integer", nullable: false),
                    IdTipoPersona = table.Column<long>(type: "bigint", nullable: true),
                    TipoLIsta = table.Column<long>(type: "bigint", nullable: true),
                    DiasPlazo = table.Column<decimal>(type: "numeric", nullable: true),
                    RazonSocial = table.Column<string>(type: "text", nullable: true),
                    tipo = table.Column<int>(type: "integer", nullable: true),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdEmpleado = table.Column<long>(type: "bigint", nullable: true),
                    Facturado = table.Column<int>(type: "integer", nullable: true),
                    Consignacion = table.Column<int>(type: "integer", nullable: true),
                    CopiaAdicionalFactura = table.Column<int>(type: "integer", nullable: true),
                    CodigoPadre = table.Column<string>(type: "text", nullable: true),
                    CantidadCompras = table.Column<short>(type: "smallint", nullable: false),
                    FechaUltimaCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdTipoDocumentoSFE = table.Column<long>(type: "bigint", nullable: true),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    AplicarSustituto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Cliente1_IdCliente1",
                        column: x => x.IdCliente1,
                        principalSchema: "ERP",
                        principalTable: "Cliente1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                schema: "ERP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoERP = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Paterno = table.Column<string>(type: "text", nullable: true),
                    Materno = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    IdNivelC1 = table.Column<long>(type: "bigint", nullable: true),
                    VisitaProgramada = table.Column<int>(type: "integer", nullable: true),
                    IdSucursal = table.Column<long>(type: "bigint", nullable: true),
                    PorcentajeDescuento = table.Column<decimal>(type: "numeric", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ValidarUbicacion = table.Column<int>(type: "integer", nullable: true),
                    tracking = table.Column<int>(type: "integer", nullable: true),
                    IdListaPrecio = table.Column<long>(type: "bigint", nullable: true),
                    ReImpresion = table.Column<int>(type: "integer", nullable: true),
                    Origen = table.Column<int>(type: "integer", nullable: true),
                    CodigoSucursalSin = table.Column<string>(type: "text", nullable: true),
                    CodigoPuntoVentaSin = table.Column<string>(type: "text", nullable: true),
                    EmpleadoFacturador = table.Column<long>(type: "bigint", nullable: true),
                    AbonoPedido = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalSchema: "GEN",
                        principalTable: "Sucursal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "SIS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Contrasena = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    IdEmpleado = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoUsuario = table.Column<long>(type: "bigint", nullable: true),
                    Imei = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalSchema: "ERP",
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalSchema: "SIS",
                        principalTable: "TipoUsuario",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "NIV",
                table: "Regional",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1L, "Santa Cruz" },
                    { 2L, "La Paz" },
                    { 3L, "Cochabamba" },
                    { 4L, "Tarija" },
                    { 5L, "Beni" }
                });

            migrationBuilder.InsertData(
                schema: "SIS",
                table: "TipoUsuario",
                columns: new[] { "Id", "Abreviatura", "CodigoERP", "Descripcion", "Tipo" },
                values: new object[,]
                {
                    { 1L, "SADM", "001", "SuperAdministrador", 1 },
                    { 2L, "ADM", "002", "Administrador", 1 }
                });

            migrationBuilder.InsertData(
                schema: "GEN",
                table: "Sucursal",
                columns: new[] { "Id", "CodigoERP", "Direccion", "Estado", "Fax", "FechaRegistro", "IdDepartamento", "IdEmpresa", "IdRegion", "IdRegional", "Latitud", "Longitud", "Lugar", "Nombre", "Registro", "Telefono", "Tipo", "ZonaFranca" },
                values: new object[,]
                {
                    { 1L, "SUC", "Av. 6 de Agosto", 1, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11042L, 1L, null, 1L, 0m, 0m, "Santa Cruz", "Santa Cruz", null, null, 1, 0 },
                    { 2L, "LPZ", "Av. 6 de Agosto", 1, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10098L, 1L, null, 2L, 0m, 0m, "La Paz", "La Paz", null, null, 1, 0 },
                    { 3L, "CBB", "Av. 6 de Agosto", 1, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10419L, 1L, null, 3L, 0m, 0m, "Cochabamba", "Cochabamba", null, null, 1, 0 },
                    { 4L, "TRJ", "Av. 6 de Agosto", 1, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10956L, 1L, null, 4L, 0m, 0m, "Tarija", "Tarija", null, null, 1, 0 },
                    { 5L, "BEN", "Av. 6 de Agosto", 1, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11191L, 1L, null, 5L, 0m, 0m, "Beni", "Beni", null, null, 1, 0 }
                });

            migrationBuilder.InsertData(
                schema: "ERP",
                table: "Empleado",
                columns: new[] { "Id", "AbonoPedido", "Celular", "CodigoERP", "CodigoPuntoVentaSin", "CodigoSucursalSin", "Direccion", "Email", "EmpleadoFacturador", "Estado", "FechaRegistro", "IdListaPrecio", "IdNivelC1", "IdSucursal", "Materno", "Nombre", "Origen", "Paterno", "PorcentajeDescuento", "ReImpresion", "Telefono", "ValidarUbicacion", "VisitaProgramada", "tracking" },
                values: new object[] { 1L, null, null, "admin", "-1", "-1", null, null, null, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 2L, null, "admin", 0, null, 0m, 0, null, 0, 0, 0 });

            migrationBuilder.InsertData(
                schema: "SIS",
                table: "Usuario",
                columns: new[] { "Id", "Contrasena", "Estado", "IdEmpleado", "IdTipoUsuario", "Imei", "Login" },
                values: new object[] { 1L, "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", 1, 1L, 1L, null, "DMS" });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCliente1",
                schema: "ERP",
                table: "Cliente",
                column: "IdCliente1");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente1_IdRegional",
                schema: "ERP",
                table: "Cliente1",
                column: "IdRegional");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdSucursal",
                schema: "ERP",
                table: "Empleado",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_IdRegional",
                schema: "GEN",
                table: "Sucursal",
                column: "IdRegional");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdEmpleado",
                schema: "SIS",
                table: "Usuario",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoUsuario",
                schema: "SIS",
                table: "Usuario",
                column: "IdTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "ERP");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "SIS");

            migrationBuilder.DropTable(
                name: "Cliente1",
                schema: "ERP");

            migrationBuilder.DropTable(
                name: "Empleado",
                schema: "ERP");

            migrationBuilder.DropTable(
                name: "TipoUsuario",
                schema: "SIS");

            migrationBuilder.DropTable(
                name: "Sucursal",
                schema: "GEN");

            migrationBuilder.DropTable(
                name: "Regional",
                schema: "NIV");
        }
    }
}
