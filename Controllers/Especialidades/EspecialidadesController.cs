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
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadesRepository _especialidadesRepository;

        public EspecialidadesController(IEspecialidadesRepository especialidadesRepository)
        {
            _especialidadesRepository = especialidadesRepository;
        }

        [HttpGet]
        public IEnumerable<Especialidad> GetEspecialidades()
        {
            return _especialidadesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var especialidad = _especialidadesRepository.GetById(id);
            if(especialidad == null)
            {
                return NotFound(new{message = "Especialidad no encontrado"});
            }
            return Ok(especialidad);
        }
    }
}