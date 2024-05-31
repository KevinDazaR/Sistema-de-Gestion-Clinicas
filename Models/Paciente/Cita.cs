using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace Simulacro2.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        public int? MedicoId { get; set; }

        [Required]
        public int? PacienteId { get; set; }

        [Required]
        public DateTime? Fecha { get; set; }

        [Required]
        public string? Estado { get; set; }
    }
}