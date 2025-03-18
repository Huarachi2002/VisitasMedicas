using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ERP");

            migrationBuilder.EnsureSchema(
                name: "SIS");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "ERP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoERP = table.Column<string>(type: "text", nullable: false),
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
                    Estado = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
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
                    Visitado = table.Column<int>(type: "integer", nullable: true),
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
                    CantidadCompras = table.Column<short>(type: "smallint", nullable: true),
                    FechaUltimaCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdTipoDocumentoSFE = table.Column<long>(type: "bigint", nullable: true),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    AplicarSustituto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
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
                    Estado = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
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
                    IdEmpleado = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "ERP");

            migrationBuilder.DropTable(
                name: "Empleado",
                schema: "ERP");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "SIS");
        }
    }
}
