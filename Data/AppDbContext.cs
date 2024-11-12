using Microsoft.EntityFrameworkCore;
using EjemploABMCompleto.Models;

namespace EjemploABMCompleto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Parque> Parques { get; set; }
        public DbSet<Atraccion> Atracciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llamada al método base para asegurarse de que la configuración predeterminada de EF se aplique
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación uno a muchos entre Parque y Atraccion:
            // Una Atraccion pertenece a un solo Parque, y un Parque puede tener muchas Atracciones
            modelBuilder.Entity<Atraccion>()
                .HasOne(atraccion => atraccion.Parque)            // Cada Atraccion tiene un Parque (relación de navegación)
                .WithMany(parque => parque.Atracciones)           // Cada Parque puede tener múltiples Atracciones (relación de navegación inversa)
                .HasForeignKey(atraccion => atraccion.IdParque);  // Se especifica IdParque como clave foránea en Atraccion
        }
    }
}
