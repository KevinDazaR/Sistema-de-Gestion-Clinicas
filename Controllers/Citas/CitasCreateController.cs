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
    public class CitasCreateController : ControllerBase
    {
        public readonly ICitasRepository _citasRepository;

         public CitasCreateController(ICitasRepository citasRepository){
            _citasRepository = citasRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Cita cita)
        {
             if (cita == null)
            {
                return BadRequest();
            }
            _citasRepository.Add(cita);

            return CreatedAtAction(nameof(Create), new {id = cita.Id}, "Cita creada con exito");
        }
    }
}