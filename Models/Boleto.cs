using System;
using System.ComponentModel.DataAnnotations;

namespace TransporteBoletos.Models
{
    public class Boleto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de boleto es obligatorio.")]
        public string NumeroBoleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de compra es obligatoria.")]
        public DateTime FechaCompra { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una ruta.")]
        public int RutaId { get; set; } // Clave foránea para Ruta
        public Ruta? Ruta { get; set; } // Propiedad de navegación

        [Required(ErrorMessage = "Debe seleccionar un pasajero.")]
        public int PasajeroId { get; set; } // Clave foránea para Pasajero
        public Pasajero? Pasajero { get; set; } // Propiedad de navegación
    }
}