using MantenimientoAutomotrizAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MantenimientoAutomotrizAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //estas propiedades DbContext representaran las tablas en SQL Server
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
    }
}