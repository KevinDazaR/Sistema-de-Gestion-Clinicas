using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Data;
using Simulacro2.Models;


namespace Simulacro2.Services.Pacientes
{
    public class PacientesRepository : IPacientesRepository
    {
        private readonly BaseContext _context;

        public PacientesRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Paciente> GetAll()
        {
            return _context.Pacientes.ToList();
        }

        public Paciente GetById(int id)
        {
            return _context.Pacientes.Find(id);
        }

        public void Add(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void Update(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if(paciente != null)
            {
                //cambiar el estado a inactivo
                paciente.Estado = "inactive";
                _context.Pacientes.Update(paciente);
                _context.SaveChanges();
            }
        }

    }
}