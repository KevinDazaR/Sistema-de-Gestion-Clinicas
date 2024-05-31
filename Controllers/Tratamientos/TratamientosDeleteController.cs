using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro2.Services.Tratamientos;
using Simulacro2.Models;
using Microsoft.EntityFrameworkCore;

namespace Simulacro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TratamientosDeleteController : ControllerBase
    {
        private readonly ITratamientosRepository _tratamientosRepository;

        public TratamientosDeleteController(ITratamientosRepository tratamientosRepository)
        {
            _tratamientosRepository = tratamientosRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTratamiento(int id)
        {
            var tratamiento = _tratamientosRepository.GetById(id);

            if (tratamiento == null)
            {
                return NotFound(new { message = "Tratamiento( no encontrado" });
            }
             try
            {
                _tratamientosRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el Tratamiento ingresado con ID: " + tratamiento.Id);
            }

            return Ok(new { message = $"Tratamiento con el ID : {id} marcado como inactivo / eliminado" });
        }
    }
}