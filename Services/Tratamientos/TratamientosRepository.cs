using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Data;
using Simulacro2.Models;


namespace Simulacro2.Services.Tratamientos
{
    public class TratamientosRepository : ITratamientosRepository
    {
        private readonly BaseContext _context;

        public TratamientosRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Tratamiento> GetAll()
        {
            return _context.Tratamientos.ToList();
        }
        public Tratamiento GetById(int id)
        {
            return _context.Tratamientos.Find(id);
        }
        public void Add(Tratamiento tratamiento)
        {
            _context.Tratamientos.Add(tratamiento);
            _context.SaveChanges();
        }
        public void Update(Tratamiento tratamiento)
        {
            _context.Tratamientos.Update(tratamiento);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if(tratamiento!= null)
            {
                //cambiar el estado a inactivo
                tratamiento.Estado = "inactive";
                _context.Tratamientos.Update(tratamiento);
                _context.SaveChanges();
            }
        }
    
    }
}