using System.Collections.Generic;

namespace TransporteBoletos.Models
{
    public class Ruta
    {
        public int Id { get; set; }
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;

        public List<Boleto> Boletos { get; set; } = new List<Boleto>(); // Relación uno a muchos con Boletos
        public List<Pasajero> Pasajeros { get; set; } = new List<Pasajero>(); // Relación uno a muchos con Pasajeros
    }
}