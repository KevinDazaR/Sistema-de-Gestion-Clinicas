using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace Simulacro2.Models
{
    public class Tratamiento
    {
        public int Id { get; set; }

        [Required]
        public int? CitaId { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Estado { get; set; }
    }
}