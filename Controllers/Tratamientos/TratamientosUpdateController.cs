using Simulacro2.Models;
using Microsoft.EntityFrameworkCore;
using Simulacro2.Services.Tratamientos;
using Simulacro2.Data;
using Microsoft.AspNetCore.Mvc;


namespace Simulacro2.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TratamientosUpdateController : ControllerBase
    {
        private readonly ITratamientosRepository _tratamientosRepository;

        public TratamientosUpdateController(ITratamientosRepository tratamientosRepository)
        {
            _tratamientosRepository = tratamientosRepository;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]Tratamiento tratamiento)
        {
            if (id!= tratamiento.Id)
            {
                return BadRequest(new { message = "el Id del Tratamiento no coincide " });
            }

            try
            {
                _tratamientosRepository.Update(tratamiento);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound(new { message = "Tratamiento no encontrado" });
            }

            return Ok(new { message = "Tratamiento actualizado" });
        }
    }
}