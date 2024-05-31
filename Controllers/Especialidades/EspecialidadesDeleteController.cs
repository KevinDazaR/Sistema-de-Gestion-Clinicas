using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro2.Services.Especialidades;
using Simulacro2.Models;
using Microsoft.EntityFrameworkCore;

namespace Simulacro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadesDeleteController : ControllerBase
    {
        private readonly IEspecialidadesRepository _especialidadesRepository;

        public EspecialidadesDeleteController(IEspecialidadesRepository especialidadesRepository)
        {
            _especialidadesRepository = especialidadesRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEspecialidad(int id)
        {
            var especialidad = _especialidadesRepository.GetById(id);

            if (especialidad == null)
            {
                return NotFound(new { message = "Especialidad no encontrada" });
            }
             try
            {
                _especialidadesRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la Especialidad ingresado con ID: " + especialidad.Id);
            }

            return Ok(new { message = $"Especialidad con el ID : {id} marcado como inactivo" });
        }
    }
}