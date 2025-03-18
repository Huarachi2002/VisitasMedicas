﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppDB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250317140645_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ERP")
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackendVisitaNET.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("AplicarSustituto")
                        .HasColumnType("integer");

                    b.Property<short?>("CantidadCompras")
                        .HasColumnType("smallint");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("Ci")
                        .HasColumnType("text");

                    b.Property<string>("CodigoERP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CodigoPadre")
                        .HasColumnType("text");

                    b.Property<int?>("Consignacion")
                        .HasColumnType("integer");

                    b.Property<int?>("CopiaAdicionalFactura")
                        .HasColumnType("integer");

                    b.Property<decimal?>("DiasPlazo")
                        .HasColumnType("numeric");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Extension")
                        .HasColumnType("text");

                    b.Property<int?>("Facturado")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaUltimaCompra")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HashCode")
                        .HasColumnType("text");

                    b.Property<long?>("IdCliente1")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdEmpleado")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdListaPrecio")
                        .HasColumnType("bigint");

                    b.Property<long>("IdNivelC1")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdPorcentajeDescuento")
                        .HasColumnType("bigint");

                    b.Property<long>("IdSucursal")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdTabla")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdTipoCliente")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdTipoDocumentoSFE")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdTipoPersona")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Latitud")
                        .HasColumnType("numeric");

                    b.Property<decimal>("LimiteCredito")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitud")
                        .HasColumnType("numeric");

                    b.Property<string>("Materno")
                        .HasColumnType("text");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Paterno")
                        .HasColumnType("text");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("text");

                    b.Property<decimal>("SaldoDeudor")
                        .HasColumnType("numeric");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.Property<long?>("TipoLIsta")
                        .HasColumnType("bigint");

                    b.Property<string>("Transaccion")
                        .HasColumnType("text");

                    b.Property<int?>("Visitado")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cliente", "ERP");
                });

            modelBuilder.Entity("BackendVisitaNET.Models.Empleado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("AbonoPedido")
                        .HasColumnType("integer");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("CodigoERP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CodigoPuntoVentaSin")
                        .HasColumnType("text");

                    b.Property<string>("CodigoSucursalSin")
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<long?>("EmpleadoFacturador")
                        .HasColumnType("bigint");

                    b.Property<int>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("IdListaPrecio")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdNivelC1")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdSucursal")
                        .HasColumnType("bigint");

                    b.Property<string>("Materno")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int?>("Origen")
                        .HasColumnType("integer");

                    b.Property<string>("Paterno")
                        .HasColumnType("text");

                    b.Property<decimal?>("PorcentajeDescuento")
                        .HasColumnType("numeric");

                    b.Property<int?>("ReImpresion")
                        .HasColumnType("integer");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.Property<int?>("ValidarUbicacion")
                        .HasColumnType("integer");

                    b.Property<int?>("VisitaProgramada")
                        .HasColumnType("integer");

                    b.Property<int?>("tracking")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Empleado", "ERP");
                });

            modelBuilder.Entity("BackendVisitaNET.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<long>("IdEmpleado")
                        .HasColumnType("bigint");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", "SIS");
                });
#pragma warning restore 612, 618
        }
    }
}
