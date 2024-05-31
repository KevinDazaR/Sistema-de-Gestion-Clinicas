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
    public class CitasController : ControllerBase
    {
        private readonly ICitasRepository _citasRepository;

        public CitasController(ICitasRepository citasRepository)
        {
            _citasRepository = citasRepository;
        }

        [HttpGet]
        public IEnumerable<Cita> GetCitas()
        {
            return _citasRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var cita = _citasRepository.GetById(id);
            if(cita == null)
            {
                return NotFound(new{message = "Cita no encontrada"});
            }
            return Ok(cita);
        }
    }
}