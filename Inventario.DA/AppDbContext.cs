using Inventario.MODEL;
using Microsoft.EntityFrameworkCore;

namespace Inventario.DA
{
    public class AppDbContext : DbContext
    {

       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  // Cada DbSet = una tabla
       public DbSet<Producto> Productos { get; set; }


        protected override void
          OnModelCreating(
            ModelBuilder modelBuilder)
        {
            // Configuración adicional
            // (restricciones, índices, etc.)
            base.OnModelCreating(
              modelBuilder);
        }


    }
}
