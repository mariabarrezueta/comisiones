using Microsoft.EntityFrameworkCore;
using MiniCoreComision.Models;

namespace MiniCoreComision.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Regla> Reglas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venta>().ToTable("Venta");
            modelBuilder.Entity<Vendedor>().ToTable("Vendedor");
            modelBuilder.Entity<Regla>().ToTable("Regla");
        }
    }
}

