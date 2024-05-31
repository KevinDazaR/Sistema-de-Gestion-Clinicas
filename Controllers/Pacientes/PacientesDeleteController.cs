using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro2.Services.Pacientes;
using Simulacro2.Models;
using Microsoft.EntityFrameworkCore;

namespace Simulacro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesDeleteController : ControllerBase
    {
        private readonly IPacientesRepository _pacientesRepository;

        public PacientesDeleteController(IPacientesRepository pacientesRepository)
        {
            _pacientesRepository = pacientesRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePaciente(int id)
        {
            var paciente = _pacientesRepository.GetById(id);

            if (paciente == null)
            {
                return NotFound(new { message = "Paciente no encontrado" });
            }
             try
            {
                _pacientesRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar al paciente ingresado con ID: " + paciente.Id);
            }

            return Ok(new { message = $"Paciente con el ID : {id} marcado como inactivo" });
        }
    }
}