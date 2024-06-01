using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Simulacro2.Models.Email;

namespace Simulacro2.Services.Emails
{
    public class MailRepository : IMailRepository
    {
        private readonly HttpClient _httpClient;

        public MailRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task EnviarCorreoAsync(Email email)
        {
            var jsonContent = JsonSerializer.Serialize(email);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            // Aquí deberías proporcionar la URL correcta para enviar el correo
            var response = await _httpClient.PostAsync("URL_DEL_SERVICIO_DE_CORREO", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
