namespace BloodBank.Core.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string content, string toEmail, string toName, byte[] attachment = null, string attachmentName = null);
    }
}
