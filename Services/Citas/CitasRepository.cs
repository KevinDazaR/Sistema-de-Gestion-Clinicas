using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Data;
using Simulacro2.Models;


namespace Simulacro2.Services.Citas
{
    public class CitasRepository : ICitasRepository
    {
        private readonly BaseContext _context;

        public CitasRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Cita> GetAll()
        {
            return _context.Citas.ToList();
        }

        public Cita GetById(int id)
        {
            return _context.Citas.Find(id);
        }

        public void Add(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
        }

        public void Update(Cita cita)
        {
            _context.Citas.Update(cita);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var cita = _context.Citas.Find(id);
            if(cita != null)
            {
                //cambiar el estado a inactivo
                cita.Estado = "inactive";
                _context.Citas.Update(cita);
                _context.SaveChanges();
            }
        }

    }
}