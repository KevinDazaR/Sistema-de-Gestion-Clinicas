using Simulacro2.Data;
using Simulacro2.Models;
using Simulacro2.Services.Tratamientos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Simulacro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TratamientoController : ControllerBase
    {
        public readonly ITratamientosRepository _tratamientosRepository;

        public TratamientoController(ITratamientosRepository tratamientosRepository)
        {
            _tratamientosRepository = tratamientosRepository;
        }

        [HttpGet]
        public IEnumerable<Tratamiento> GetAll()
        {
            return _tratamientosRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var tratamiento = _tratamientosRepository.GetById(id);
            if(tratamiento == null)
            {
                return NotFound(new{message = "Tratamiento no encontrado"});
            }
            return Ok(tratamiento);
        }
    }
}