using System.Threading.Tasks;
using Simulacro2.Models.Email;
using Simulacro2.Models;
using Simulacro2.Services.Emails;
using Simulacro2.Data;


namespace Simulacro2.Services.Emails
{
    public interface IMailRepository
    {
        Task EnviarCorreoAsync(Email email);
    }
}
