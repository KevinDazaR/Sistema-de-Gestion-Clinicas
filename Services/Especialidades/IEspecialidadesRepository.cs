using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Models;

namespace Simulacro2.Services.Especialidades
{
    public interface IEspecialidadesRepository
    {
         IEnumerable<Especialidad> GetAll();
         Especialidad GetById(int id);
         void Add(Especialidad especialidad);
         void Update(Especialidad especialidad);
         void Delete(int id);
    }
}