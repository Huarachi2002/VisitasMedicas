using Microsoft.EntityFrameworkCore;
using BackendVisitaNET.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Especificar el esquema ERP en PostgreSQL
        modelBuilder.HasDefaultSchema("ERP");

        modelBuilder.Entity<Cliente>()
            .ToTable("Cliente", "ERP")
            .Property(c => c.Estado)
            .HasDefaultValue(1); // Por defecto, activo

        modelBuilder.Entity<Empleado>()
            .ToTable("Empleado", "ERP")
            .Property(e => e.Estado)
            .HasDefaultValue(1); // Por defecto, activo

        modelBuilder.Entity<Usuario>()
            .ToTable("Usuario", "SIS");
    }

}
