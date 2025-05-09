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
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
    }
}