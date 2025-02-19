using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro2.Models;
using Microsoft.EntityFrameworkCore;
using Simulacro2.Services;

namespace Simulacro2.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options): base(options)
        {

        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
    }
}