using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Models;

namespace Simulacro2.Services.Pacientes
{
    public interface IPacientesRepository
    {
         IEnumerable<Paciente> GetAll();
         Paciente GetById(int id);
         void Add(Paciente paciente);
         void Update(Paciente paciente);
         void Delete(int id);
    }
}