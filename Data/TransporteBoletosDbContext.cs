using Microsoft.EntityFrameworkCore;
using TransporteBoletos.Models;

namespace TransporteBoletos.Data
{
    public class TransporteBoletosDbContext : DbContext
    {
        public TransporteBoletosDbContext(DbContextOptions<TransporteBoletosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Ruta> Rutas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Ruta)
                .WithMany(r => r.Boletos)
                .HasForeignKey(b => b.RutaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Pasajero)
                .WithMany(p => p.Boletos)
                .HasForeignKey(b => b.PasajeroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pasajero>()
                .HasOne(p => p.Ruta)
                .WithMany(r => r.Pasajeros)
                .HasForeignKey(p => p.RutaId)
                .OnDelete(DeleteBehavior.SetNull);

            // Seeder para datos iniciales
            modelBuilder.Entity<Ruta>().HasData(
                new Ruta { Id = 1, Origen = "Ciudad A", Destino = "Ciudad B" },
                new Ruta { Id = 2, Origen = "Ciudad B", Destino = "Ciudad C" }
            );

            modelBuilder.Entity<Pasajero>().HasData(
                new Pasajero { Id = 1, Nombre = "Juan Pérez", Documento = "12345678", RutaId = 1 }
            );

            modelBuilder.Entity<Boleto>().HasData(
                new Boleto
                {
                    Id = 1,
                    NumeroBoleto = "B001",
                    FechaCompra = new DateTime(2025, 5, 8, 0, 0, 0, DateTimeKind.Utc), // Valor estático
                    RutaId = 1,
                    PasajeroId = 1
                }
            );
        }
    }
}