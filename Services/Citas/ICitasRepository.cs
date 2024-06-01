using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Models;
using Simulacro2.Services.Emails;

namespace Simulacro2.Services.Citas
{
    public interface ICitasRepository
    {
         IEnumerable<Cita> GetAll();
         Cita GetById(int id);
         void Add(Cita cita);
         void Update(Cita cita);
         void Delete(int id);
    }
}