using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro2.Services.Medicos;
using Simulacro2.Models;
using Microsoft.EntityFrameworkCore;

namespace Simulacro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosDeleteController : ControllerBase
    {
        private readonly IMedicosRepository _medicosRepository;

        public MedicosDeleteController(IMedicosRepository medicosRepository)
        {
            _medicosRepository = medicosRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMedico(int id)
        {
            var medico = _medicosRepository.GetById(id);

            if (medico == null)
            {
                return NotFound(new { message = "Medico no encontrada" });
            }
             try
            {
                _medicosRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la Medico ingresado con ID: " + medico.Id);
            }

            return Ok(new { message = $"Medico con el ID : {id} marcado como inactivo" });
        }
    }
}