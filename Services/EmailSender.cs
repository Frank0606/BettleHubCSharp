using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BettleHubCsharp.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _smtpEmail = "frankdanielsanchez55@gmail.com";
        private readonly string _smtpPassword = "ratb ndsj vzzg wafs";

        public Task SendEmailAsync(string email, string subject, string body)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(_smtpEmail, _smtpPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            return client.SendMailAsync(mailMessage);
        }
    }
}
