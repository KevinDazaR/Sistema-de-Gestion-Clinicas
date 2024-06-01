using System.Threading.Tasks;
using Simulacro2.Models.Email;
using Simulacro2.Models;
using Simulacro2.Services.Emails;


namespace Simulacro2.Services.Email
{
    public interface IMailRepository
    {
        Task EnviarCorreoAsync(Email email);
    }
}
