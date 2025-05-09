using System.ComponentModel.DataAnnotations;

namespace TransporteBoletos.Models
{
    public class Pasajero
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "La cédula debe tener entre 7 y 10 dígitos.")]
        [RegularExpression(@"^\d{7,10}$", ErrorMessage = "La cédula debe contener solo números y tener entre 7 y 10 dígitos.")]
        public string Documento { get; set; } = string.Empty;
        public List<Boleto> Boletos { get; set; } = new List<Boleto>();
        public int? RutaId { get; set; } // Permitir nulo si no siempre se asigna una ruta
        public Ruta? Ruta { get; set; }
    }
}