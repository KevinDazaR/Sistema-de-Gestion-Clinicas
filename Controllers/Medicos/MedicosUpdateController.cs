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
    public class MedicoUpdateController : ControllerBase
    {
        private readonly IMedicosRepository _medicosRepository;

        public MedicoUpdateController(IMedicosRepository medicosRepository)
        {
            _medicosRepository = medicosRepository;
        }
 
        [HttpPut("{id}")]
        public IActionResult UpdateMedico(int id, Medico medico)
        {
            if (id != medico.Id)
            {
                return BadRequest(new { message = "el Id de la medico no coincide " });
            }

            try
            {
                _medicosRepository.Update(medico);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_medicosRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "medico no encontrada" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdateMedico), new {id = medico.Id}, "Medico actualizada con exito");
        }

    }
}