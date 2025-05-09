namespace TransporteBoletos.Models
{
    public class Boleto
    {
        public int Id { get; set; }
        public string NumeroBoleto { get; set; } = string.Empty;
        public int RutaId { get; set; }
        public int PasajeroId { get; set; }
        public DateTime FechaCompra { get; set; }
        public Ruta? Ruta { get; set; }
        public Pasajero? Pasajero { get; set; }
    }
}