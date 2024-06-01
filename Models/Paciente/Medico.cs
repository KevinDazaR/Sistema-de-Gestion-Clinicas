using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered
using Simulacro2.Services.Citas;

namespace Simulacro2.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required]
        public string? NombreCompleto { get; set; }

        [Required]
        public int? EspecialidadId { get; set; }

        [Required]
        public string? Correo { get; set; }

        [Required]
        public string? Telefono { get; set; }

        [Required]
        public string? Estado { get; set; }
    }
}