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
    public class PacientesCreateController : ControllerBase
    {
        public readonly IPacientesRepository _pacientesRepository;

         public PacientesCreateController(IPacientesRepository pacientesRepository){
            _pacientesRepository = pacientesRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Paciente paciente)
        {
             if (paciente == null)
            {
                return BadRequest();
            }
            _pacientesRepository.Add(paciente);

            return CreatedAtAction(nameof(Create), new {id = paciente.Id}, "Paciente creado con exito");
        }
    }
}