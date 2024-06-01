using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Simulacro2.Services.Citas;
using Simulacro2.Services.Emails;


namespace Simulacro2.Controllers.Emails
{
    public class MailRepository: MailRepository
    {
        public async Task EnviarCorreoAsync()
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";
                string jwtToken = "mlsn.98baf48789cc15783ed25cc047098fbfcd649d27422c99849b7e70e8512cd5fa";

                var emailMessage = new
                {
                    from = new { email = "trial-zr6ke4njjz3gon12@mlsender.net" },
                    to = new[]
                    {
                        new { email = "kevindaza13@gmail.com" }
                    },
                    subject = "Hello from MailerSend!",
                    text = "Greetings from the team, you got this message through MailerSend.",
                    html = "Greetings from the team, you got this message through MailerSend."
                };

                string jsonBody = JsonSerializer.Serialize(emailMessage);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor:");
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"La solicitud falló con el código del estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
