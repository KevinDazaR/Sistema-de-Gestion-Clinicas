using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace Simulacro2.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        
        [Required]
        public string ? Nombres { get; set; }

        [Required]
        public string ? Apellidos {get;set;}

        [Required]
        public DateTime FechaNacimiento {get;set;}

        [Required]
        public string ? Correo {get;set;}

        [Required]
        public string ? Telefono {get;set;}

        [Required]
        public string ? Direccion {get;set;}

       [Required] 
        public string ? Estado {get;set;} // Consultar Còmo hacer para que sea por defecto ACTIVE
    }
}