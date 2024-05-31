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
    public class MedicosCreateController : ControllerBase
    {
        public readonly IMedicosRepository _medicoRepository;

         public MedicosCreateController(IMedicosRepository medicoRepository){
            _medicoRepository = medicoRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Medico medico)
        {
             if (medico == null)
            {
                return BadRequest();
            }
            _medicoRepository.Add(medico);

            return CreatedAtAction(nameof(Create), new {id = medico.Id}, "Medico creada con exito");
        }
    }
}