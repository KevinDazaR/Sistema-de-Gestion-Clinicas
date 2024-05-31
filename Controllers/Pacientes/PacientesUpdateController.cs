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
    public class PacientesUpdateController : ControllerBase
    {
        private readonly IPacientesRepository _pacientesRepository;

        public PacientesUpdateController(IPacientesRepository pacientesRepository)
        {
            _pacientesRepository = pacientesRepository;
        }
 
        [HttpPut("{id}")]
        public IActionResult UpdatePaciente(int id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest(new { message = "el Id del Paciente no coincide " });
            }

            try
            {
                _pacientesRepository.Update(paciente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_pacientesRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Paciente no encontrado" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdatePaciente), new {id = paciente.Id}, "Paciente actualizado con exito");
        }

    }
}