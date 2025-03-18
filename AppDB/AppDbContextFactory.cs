using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AppDB
{
    class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContextFactory() { }

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Coloca aquí la ruta absoluta o relativa correcta al proyecto Api
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Api");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PostgresConnection");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception($"Cadena de conexión no encontrada en: {basePath}");

            optionsBuilder.UseNpgsql(connectionString,
                                     b => b.MigrationsAssembly("AppDB"));

            return new AppDbContext(optionsBuilder.Options);
        }


    }
}
