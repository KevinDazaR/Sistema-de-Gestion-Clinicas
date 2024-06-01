using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Simulacro2.Data;
using Simulacro2.Models;
using Simulacro2.Models.Email;
using Simulacro2.Services.Emails;



namespace Simulacro2.Services.Citas
{
    public class CitasRepository : ICitasRepository
    {
        private readonly BaseContext _context;
        private readonly MailRepository _mailRepository;

        public CitasRepository(BaseContext context, MailRepository mailRepository)
        {
            _context = context;
            _mailRepository = mailRepository;
        }

        public IEnumerable<Cita> GetAll()
        {
            return _context.Citas
                // .Include(x => x.Medico)
                // .Include(x => x.Paciente)
                .ToList();
        }

        public Cita GetById(int id)
        {
            return _context.Citas
                // .Include(x => x.Medico)
                // .Include(x => x.Paciente)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Add(Cita cita)
        {
            _context.Citas.Add(cita);
            

            // Lógica para enviar el correo
            var email = new Email
            {
                From = new From { Email = "trial-zr6ke4njjz3gon12.mlsender.net" },
                To = new List<To> { new To { Email = "kevindaza13@gmail.com" } },
                Subject = "Cita Creada",
                Text = "Su cita ha sido creada exitosamente.",
                Html = "<p>Su cita ha sido creada exitosamente.</p>"
            };
            _mailRepository.EnviarCorreoAsync(email).GetAwaiter().GetResult();
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
            if (cita != null)
            {
                cita.Estado = "inactive";
                _context.Citas.Update(cita);
                _context.SaveChanges();
            }
        }
    }
}
