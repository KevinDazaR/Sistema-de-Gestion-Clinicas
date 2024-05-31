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
    public class MedicosController : ControllerBase
    {
        private readonly IMedicosRepository _medicosRepository;

        public MedicosController(IMedicosRepository medicosRepository)
        {
            _medicosRepository = medicosRepository;
        }

        [HttpGet]
        public IEnumerable<Medico> GetMedicos()
        {
            return _medicosRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var medico = _medicosRepository.GetById(id);
            if(medico == null)
            {
                return NotFound(new{message = "Medico no encontrado"});
            }
            return Ok(medico);
        }
    }
}