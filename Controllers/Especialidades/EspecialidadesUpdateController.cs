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
    public class EspecialidadesUpdateController : ControllerBase
    {
        private readonly IEspecialidadesRepository _especialidadesRepository;

        public EspecialidadesUpdateController(IEspecialidadesRepository especialidadesRepository)
        {
            _especialidadesRepository = especialidadesRepository;
        }
 
        [HttpPut("{id}")]
        public IActionResult UpdateEspecialidad(int id, Especialidad especialidad)
        {
            if (id != especialidad.Id)
            {
                return BadRequest(new { message = "el Id de la Especialidad no coincide " });
            }

            try
            {
                _especialidadesRepository.Update(especialidad);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_especialidadesRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Especialidad no encontrada" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdateEspecialidad), new {id = especialidad.Id}, "Especialidad actualizada con exito");
        }

    }
}