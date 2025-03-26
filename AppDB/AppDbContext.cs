using Microsoft.EntityFrameworkCore;
using AppDB.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Cliente1> Cliente1 { get; set; }
    public DbSet<TipoUsuario> TipoUsuarios { get; set; }
    public DbSet<Regional> Regional { get; set; }
    public DbSet<Sucursal> Sucursal { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<EmpleadoEspecialidad> EmpleadoEspecialidades { get; set; }
    public DbSet<Periodo> Periodos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: Periodo
        modelBuilder.Entity<Periodo>()
            .ToTable("Periodo", "ERP")
            .HasData(
                new Periodo { Id = 1, Nombre = "2024 - Enero", FechaInicio = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 1, 31, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 2, Nombre = "2024 - Febrero", FechaInicio = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 2, 29, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 3, Nombre = "2024 - Marzo", FechaInicio = new DateTime(2024, 3, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 3, 31, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 4, Nombre = "2024 - Abril", FechaInicio = new DateTime(2024, 4, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 4, 30, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 5, Nombre = "2024 - Mayo", FechaInicio = new DateTime(2024, 5, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 5, 31, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 6, Nombre = "2024 - Junio", FechaInicio = new DateTime(2024, 6, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 6, 30, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 7, Nombre = "2024 - Julio", FechaInicio = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 7, 31, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 8, Nombre = "2024 - Agosto", FechaInicio = new DateTime(2024, 8, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 8, 31, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 9, Nombre = "2024 - Septiembre", FechaInicio = new DateTime(2024, 9, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 9, 30, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 10, Nombre = "2024 - Octubre", FechaInicio = new DateTime(2024, 10, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 10, 31, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 11, Nombre = "2024 - Noviembre", FechaInicio = new DateTime(2024, 11, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 11, 30, 0, 0, 0, DateTimeKind.Utc) },
                new Periodo { Id = 12, Nombre = "2024 - Diciembre", FechaInicio = new DateTime(2024, 12, 1, 0, 0, 0, DateTimeKind.Utc), FechaFin = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Utc) }
            );


        // TODO: Categoria
        modelBuilder.Entity<Categoria>()
            .ToTable("Categoria", "ERP")
            .HasData(
                new Categoria { Id = 1, Nombre = "A", Descripcion = "4 veces x mes" },
                new Categoria { Id = 2, Nombre = "B", Descripcion = "2 veces x mes" },
                new Categoria { Id = 3, Nombre = "C", Descripcion = "1 vez x mes" }
            );

        // TODO: Especialidad
        modelBuilder.Entity<Especialidad>()
            .ToTable("Especialidad", "ERP")
            .HasData(
                new Especialidad { Id = 1, Nombre = "CAR - CARDIOLOGIA" },
                new Especialidad { Id = 2, Nombre = "CIR - CIRUGIA" },
                new Especialidad { Id = 3, Nombre = "GIN - GINECOLOGIA" },
                new Especialidad { Id = 4, Nombre = "MGE - MEDICINA GENERAL" },
                new Especialidad { Id = 5, Nombre = "MIN - MEDICINA INTERNA" },
                new Especialidad { Id = 6, Nombre = "ODO - ODONTOLOGIA" },
                new Especialidad { Id = 7, Nombre = "PED - PEDIATRIA" },
                new Especialidad { Id = 8, Nombre = "TRA - TRAUMATOLOGIA" }
            );


        // TODO: Regional
        modelBuilder.Entity<Regional>()
            .ToTable("Regional", "NIV")
            .HasData(
                new Regional { Id = 1, Nombre = "Santa Cruz" },
                new Regional { Id = 2, Nombre = "La Paz" },
                new Regional { Id = 3, Nombre = "Cochabamba" },
                new Regional { Id = 4, Nombre = "Tarija" },
                new Regional { Id = 5, Nombre = "Beni" }
            );

        // TODO: Sucursal
        modelBuilder.Entity<Sucursal>()
            .HasOne(su => su.Regional)
            .WithMany()
            .HasForeignKey(su => su.IdRegional);

        modelBuilder.Entity<Sucursal>()
            .Property(s => s.FechaRegistro)
            .HasColumnType("timestamp with time zone");

        modelBuilder.Entity<Sucursal>()
            .ToTable("Sucursal", "GEN")
            .HasData(
                new Sucursal { Id = 1, CodigoERP = "SUC", Nombre = "Santa Cruz", Direccion = "Av. 6 de Agosto", IdDepartamento = 11042, FechaRegistro = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), Estado = 1, IdEmpresa = 1, IdRegional = 1, Tipo = 1, Latitud = 0, Longitud = 0, Lugar = "Santa Cruz", ZonaFranca = 0 },
                new Sucursal { Id = 2, CodigoERP = "LPZ", Nombre = "La Paz", Direccion = "Av. 6 de Agosto", IdDepartamento = 10098, FechaRegistro = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), Estado = 1, IdEmpresa = 1, IdRegional = 2, Tipo = 1, Latitud = 0, Longitud = 0, Lugar = "La Paz", ZonaFranca = 0 },
                new Sucursal { Id = 3, CodigoERP = "CBB", Nombre = "Cochabamba", Direccion = "Av. 6 de Agosto", IdDepartamento = 10419, FechaRegistro = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), Estado = 1, IdEmpresa = 1, IdRegional = 3, Tipo = 1, Latitud = 0, Longitud = 0, Lugar = "Cochabamba", ZonaFranca = 0 },
                new Sucursal { Id = 4, CodigoERP = "TRJ", Nombre = "Tarija", Direccion = "Av. 6 de Agosto", IdDepartamento = 10956, FechaRegistro = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), Estado = 1, IdEmpresa = 1, IdRegional = 4, Tipo = 1, Latitud = 0, Longitud = 0, Lugar = "Tarija", ZonaFranca = 0 },
                new Sucursal { Id = 5, CodigoERP = "BEN", Nombre = "Beni", Direccion = "Av. 6 de Agosto", IdDepartamento = 11191, FechaRegistro = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), Estado = 1, IdEmpresa = 1, IdRegional = 5, Tipo = 1, Latitud = 0, Longitud = 0, Lugar = "Beni", ZonaFranca = 0 }
            );


        // TODO: TipoUsuario
        modelBuilder.Entity<TipoUsuario>()
            .ToTable("TipoUsuario", "SIS")
            .HasData(
                new TipoUsuario { Id = 1, CodigoERP = "001", Descripcion = "SuperAdministrador", Abreviatura = "SADM", Tipo = 1 },
                new TipoUsuario { Id = 2, CodigoERP = "002", Descripcion = "Administrador", Abreviatura = "ADM", Tipo = 1 },
                new TipoUsuario { Id = 3, CodigoERP = "003", Descripcion = "Supervisor", Abreviatura = "SUP", Tipo = 1 },
                new TipoUsuario { Id = 4, CodigoERP = "004", Descripcion = "Visitador", Abreviatura = "VIS", Tipo = 1 }
            );


        // TODO: Usuario
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.TipoUsuario)
            .WithMany()
            .HasForeignKey(u => u.IdTipoUsuario);
        
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Empleado)
            .WithMany()
            .HasForeignKey(u => u.IdEmpleado);

        modelBuilder.Entity<Usuario>()
            .ToTable("Usuario", "SIS")
            .HasData(
                new Usuario { Id = 1, Login = "DMS", Contrasena = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", Estado = 1, IdEmpleado = 1, IdTipoUsuario = 1, Imei = null },
                new Usuario { Id = 2, Login = "admin", Contrasena = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", Estado = 1, IdEmpleado = 1, IdTipoUsuario = 2, Imei = null },
                new Usuario { Id = 3, Login = "sup", Contrasena = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", Estado = 1, IdEmpleado = 2, IdTipoUsuario = 3, Imei = null },
                new Usuario { Id = 4, Login = "vis", Contrasena = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", Estado = 1, IdEmpleado = 3, IdTipoUsuario = 4, Imei = null }
            );
        

        // TODO: Cliente
        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Cliente1)
            .WithMany()
            .HasForeignKey(c => c.IdCliente1);

        modelBuilder.Entity<Cliente1>()
            .Property(c => c.FechaNacimiento)
            .HasColumnType("timestamp with time zone");

        modelBuilder.Entity<Cliente>()
            .Property(c => c.FechaRegistro)
            .HasColumnType("timestamp with time zone");

        modelBuilder.Entity<Cliente>()
            .Property(c => c.fecha)
            .HasColumnType("timestamp with time zone");

        modelBuilder.Entity<Cliente>()
            .Property(c => c.FechaUltimaCompra)
            .HasColumnType("timestamp with time zone");


        // TODO: Empleado
        modelBuilder.Entity<Empleado>()
            .HasOne(e => e.Sucursal)
            .WithMany()
            .HasForeignKey(e => e.IdSucursal);

        modelBuilder.Entity<Empleado>()
            .Property(e => e.FechaRegistro)
            .HasColumnType("timestamp with time zone");

        modelBuilder.Entity<Empleado>()
            .ToTable("Empleado", "ERP")
            .HasData(
                new Empleado { Id = 1, CodigoERP = "admin", Nombre = "admin", Paterno = null, Materno = null, Direccion = null, Telefono = null, Celular = null, FechaRegistro = new DateTime(2023, 2, 2, 0, 0, 0, DateTimeKind.Utc), Estado = 2, IdNivelC1 = null, VisitaProgramada = 0, IdSucursal = 2, PorcentajeDescuento = 0, Email = null, ValidarUbicacion = 0, tracking = 0, IdListaPrecio = null, ReImpresion = 0, Origen = 0, CodigoSucursalSin = "-1", CodigoPuntoVentaSin = "-1", EmpleadoFacturador = null, AbonoPedido = null },
                new Empleado { Id = 2, CodigoERP = "sup", Nombre = "sup", Paterno = null, Materno = null, Direccion = null, Telefono = null, Celular = null, FechaRegistro = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), Estado = 1, IdNivelC1 = null, VisitaProgramada = 0, IdSucursal = 3, PorcentajeDescuento = 0, Email = null, ValidarUbicacion = 0, tracking = 0, IdListaPrecio = null, ReImpresion = 0, Origen = 0, CodigoSucursalSin = "-1", CodigoPuntoVentaSin = "-1", EmpleadoFacturador = null, AbonoPedido = null },
                new Empleado { Id = 3, CodigoERP = "vis", Nombre = "vis", Paterno = null, Materno = null, Direccion = null, Telefono = null, Celular = null, FechaRegistro = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), Estado = 1, IdNivelC1 = null, VisitaProgramada = 0, IdSucursal = 1, PorcentajeDescuento = 0, Email = null, ValidarUbicacion = 0, tracking = 0, IdListaPrecio = null, ReImpresion = 0, Origen = 0, CodigoSucursalSin = "-1", CodigoPuntoVentaSin = "-1", EmpleadoFacturador = null, AbonoPedido = null }
            );

        // TODO: EmpleadoEspecialidad
        modelBuilder.Entity<EmpleadoEspecialidad>()
            .HasOne(e => e.Empleado)
            .WithMany(e => e.EmpleadoEspecialidades)
            .HasForeignKey(e => e.IdEmpleado);

        modelBuilder.Entity<EmpleadoEspecialidad>()
            .HasOne(e => e.Especialidad)
            .WithMany(e => e.EmpleadoEspecialidades)
            .HasForeignKey(e => e.IdEspecialidad);

        modelBuilder.Entity<EmpleadoEspecialidad>()
            .HasKey(ee => new { ee.IdEmpleado, ee.IdEspecialidad });

        // TOOD: Cliente1
        modelBuilder.Entity<Cliente1>()
            .HasOne(c1 => c1.Regional)
            .WithMany()
            .HasForeignKey(c1 => c1.IdRegional);

        modelBuilder.Entity<Cliente1>()
            .HasOne(c1 => c1.Categoria)
            .WithMany()
            .HasForeignKey(c1 => c1.IdCategoria);

        modelBuilder.Entity<Cliente1>()
            .ToTable("Cliente1", "ERP");
    }

}
