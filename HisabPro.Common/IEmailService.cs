using HisabPro.Constants;

namespace HisabPro.Common
{
    public interface IEmailService
    {
        Task SendEmailAsync(EnumEmailTypes emailType, string toEmail, object placeholders);
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
