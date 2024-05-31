using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Models;

namespace Simulacro2.Services.Tratamientos
{
    public interface ITratamientosRepository
    {
         IEnumerable<Tratamiento> GetAll();
         Tratamiento GetById(int id);
         void Add(Tratamiento tratamiento);
         void Update(Tratamiento tratamiento);
         void Delete(int id);
    }
}