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
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesRepository _pacientesRepository;

        public PacientesController(IPacientesRepository pacientesRepository)
        {
            _pacientesRepository = pacientesRepository;
        }

        [HttpGet]
        public IEnumerable<Paciente> GetPacientes()
        {
            return _pacientesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var paciente = _pacientesRepository.GetById(id);
            if(paciente == null)
            {
                return NotFound(new{message = "Paciente no encontrado"});
            }
            return Ok(paciente);
        }
    }
}