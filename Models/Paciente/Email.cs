using System.Collections.Generic;
using Simulacro2.Services.Emails;


namespace Simulacro2.Models.Email
{
    public class Email
    {
        public From From { get; set; }
        public List<To> To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
    }

    public class From
    {
        public string Email { get; set; }
    }

    public class To
    {
        public string Email { get; set; }
    }
}
