using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Data;
using Simulacro2.Models;
using Simulacro2.Services.Especialidades;

namespace Simulacro2.Services.Especialidades
{
    public class EspecialidadesRepository : IEspecialidadesRepository
    {
        private readonly BaseContext _context;

        public EspecialidadesRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Especialidad> GetAll()
        {
            return _context.Especialidades.ToList();
        }

        public Especialidad GetById(int id)
        {
            return _context.Especialidades.Find(id);
        }

        public void Add(Especialidad especialidad)
        {
            _context.Especialidades.Add(especialidad);
            _context.SaveChanges();
        }

        public void Update(Especialidad especialidad)
        {
            _context.Especialidades.Update(especialidad);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var especialidad = _context.Especialidades.Find(id);
            if(especialidad != null)
            {
                //cambiar el estado a inactivo
                especialidad.Estado = "inactive";
                _context.Especialidades.Update(especialidad);
                _context.SaveChanges();
            }
        }

    }
}