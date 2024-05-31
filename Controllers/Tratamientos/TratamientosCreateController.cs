using Simulacro2.Models;
using Simulacro2.Data;
using Simulacro2.Services.Tratamientos;
using Microsoft.AspNetCore.Mvc;

namespace Simulacro2.Controllers
{
    [ApiController]
    [Route("api/create")]
    public class TratamientosCreateController : ControllerBase
    {
        private readonly ITratamientosRepository _tratamientosRepository;

        public TratamientosCreateController(ITratamientosRepository tratamientosRepository)
        {
            _tratamientosRepository = tratamientosRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Tratamiento tratamiento)
        {
            if(tratamiento == null)
            {
                return BadRequest("No se ingresò un tratamiento vàlido");
            }
            
            _tratamientosRepository.Add(tratamiento);

            return CreatedAtAction(nameof(Create), new {id = tratamiento.Id}, "Tratamiento creado con exito");
        }
    }
}