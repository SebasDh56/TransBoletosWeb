using System.ComponentModel.DataAnnotations;

namespace TransporteBoletos.Models
{
    public class Pasajero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El documento es obligatorio.")]
        public string Documento { get; set; } = string.Empty;

        public int? RutaId { get; set; } // Clave foránea para Ruta (nullable si no siempre requiere una ruta)
        public Ruta? Ruta { get; set; } // Propiedad de navegación

        public List<Boleto> Boletos { get; set; } = new List<Boleto>(); // Relación uno a muchos
    }
}