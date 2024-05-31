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
    public class CitasUpdateController : ControllerBase
    {
        private readonly ICitasRepository _citasRepository;

        public CitasUpdateController(ICitasRepository citasRepository)
        {
            _citasRepository = citasRepository;
        }
 
        [HttpPut("{id}")]
        public IActionResult UpdateCita(int id, Cita cita)
        {
            if (id != cita.Id)
            {
                return BadRequest(new { message = "el Id de la Cita no coincide " });
            }

            try
            {
                _citasRepository.Update(cita);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_citasRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Cita no encontrada" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdateCita), new {id = cita.Id}, "Cita actualizada con exito");
        }

    }
}