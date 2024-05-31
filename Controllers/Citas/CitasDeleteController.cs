using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro2.Services.Citas;
using Simulacro2.Models;
using Microsoft.EntityFrameworkCore;

namespace Simulacro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasDeleteController : ControllerBase
    {
        private readonly ICitasRepository _citasRepository;

        public CitasDeleteController(ICitasRepository citasRepository)
        {
            _citasRepository = citasRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCita(int id)
        {
            var cita = _citasRepository.GetById(id);

            if (cita == null)
            {
                return NotFound(new { message = "Cita no encontrada" });
            }
             try
            {
                _citasRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la Cita ingresado con ID: " + cita.Id);
            }

            return Ok(new { message = $"Cita con el ID : {id} marcado como inactivo / eliminado" });
        }
    }
}