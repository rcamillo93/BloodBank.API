using BloodBank.Core.Services;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace BloodBank.Infrastructure.Notifications
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpServer = _configuration["SmtpSettings:Server"];
            _smtpPort = int.Parse(_configuration["SmtpSettings:Port"]);
            _smtpUser = _configuration["SmtpSettings:User"];
            _smtpPass = _configuration["SmtpSettings:Pass"];

        }

        public async Task SendEmailAsync(string subject, string content, string toEmail, string toName, byte[] attachment = null, string attachmentName = null)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("BloodBank", _smtpUser));
            email.To.Add(new MailboxAddress(toName, toEmail));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = content
            };

            // Adiciona o anexo, se fornecido
            if (attachment != null && !string.IsNullOrEmpty(attachmentName))
            {
                bodyBuilder.Attachments.Add(attachmentName, attachment);
            }

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_smtpUser, _smtpPass);

                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
    }
}
