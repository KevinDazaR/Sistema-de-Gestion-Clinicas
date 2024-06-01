using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Simulacro2.Models.Email;


namespace Simulacro2.Services.Emails
{
    public class MailRepository 
    {
        private readonly HttpClient _httpClient;

        public MailRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task EnviarCorreoAsyn(Email email)
        {
            string url = "https://api.mailersend.com/v1/email";
            string jwtToken = "mlsn.98baf48789cc15783ed25cc047098fbfcd649d27422c99849b7e70e8512cd5fa";
            
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

            var jsonBody = JsonSerializer.Serialize(email);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
