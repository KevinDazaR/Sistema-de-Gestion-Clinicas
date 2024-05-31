using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Data;
using Simulacro2.Models;


namespace Simulacro2.Services.Medicos
{
    public class MedicosRepository : IMedicosRepository
    {
        private readonly BaseContext _context;

        public MedicosRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Medico> GetAll()
        {
            return _context.Medicos.ToList();
        }

        public Medico GetById(int id)
        {
            return _context.Medicos.Find(id);
        }

        public void Add(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
        }

        public void Update(Medico medico)
        {
            _context.Medicos.Update(medico);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var medico = _context.Medicos.Find(id);
            if(medico != null)
            {
                //cambiar el estado a inactivo
                medico.Estado = "inactive";
                _context.Medicos.Update(medico);
                _context.SaveChanges();
            }
        }

    }
}