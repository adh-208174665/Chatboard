using System.Net;
using System.Net.Mail;

namespace SonkeTransportManagement.Sevices
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(string to, string subject, string body)
        {
            var smtpSettings = _config.GetSection("Smtp");

            using (var client = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"])))
            {
                client.Credentials = new NetworkCredential(smtpSettings["UserName"], smtpSettings["Password"]);
                client.EnableSsl = bool.Parse(smtpSettings["EnableSsl"]);

                var mail = new MailMessage();
                mail.From = new MailAddress(smtpSettings["From"]);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = @body;

                client.Send(mail);
            }
        }
    }
}
