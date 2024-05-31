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
    public class EspecialidadesCreateController : ControllerBase
    {
        public readonly IEspecialidadesRepository _especialidadesRepository;

         public EspecialidadesCreateController(IEspecialidadesRepository especialidadesRepository){
            _especialidadesRepository = especialidadesRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Especialidad especialidad)
        {
             if (especialidad == null)
            {
                return BadRequest();
            }
            _especialidadesRepository.Add(especialidad);

            return CreatedAtAction(nameof(Create), new {id = especialidad.Id}, "Especialidad creada con exito");
        }
    }
}