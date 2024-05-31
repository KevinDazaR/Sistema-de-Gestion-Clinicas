using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Models;

namespace Simulacro2.Services.Medicos
{
    public interface IMedicosRepository
    {
         IEnumerable<Medico> GetAll();
         Medico GetById(int id);
         void Add(Medico medico);
         void Update(Medico medico);
         void Delete(int id);
    }
}