using HisabPro.Constants;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace HisabPro.Common
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _templatesPath;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _templatesPath = Path.Combine(Directory.GetCurrentDirectory(), AppConst.Configs.EmailTemplatesFolder);
        }

        public async Task SendEmailAsync(EnumEmailTypes emailType, string toEmail, object placeholders)
        {
            string emailBody = "";
            string emailTitle = "";
            if (emailType == EnumEmailTypes.ActivateAccount)
            {
                emailBody = await ReplacePlaceholders("ActivateAccount.html", placeholders);
                emailTitle = "Activate Your Account";
            }

            await SendEmailAsync(toEmail, emailTitle, emailBody);
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpSettings = _configuration.GetSection("EmailSettings");
            string user = smtpSettings["UserName"];
            string password = smtpSettings["Password"];
            bool ssl = true;
            var smtpClient = new SmtpClient
            {
                Host = smtpSettings["Host"],
                Port = int.Parse(smtpSettings["Port"]),
                EnableSsl = ssl,
                Credentials = new NetworkCredential(user, password)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpSettings["FromEmail"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);
            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
            }
        }

        private async Task<string> ReplacePlaceholders(string templateFileName, object placeholders)
        {
            string templatePath = Path.Combine(_templatesPath, templateFileName);

            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Template {templateFileName} not found in {_templatesPath}");

            string templateContent = await File.ReadAllTextAsync(templatePath);

            // Convert placeholders object to dictionary
            var placeholderDictionary = placeholders.GetType()
                .GetProperties()
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(placeholders)?.ToString() ?? string.Empty);

            // Replace placeholders in the template
            foreach (var placeholder in placeholderDictionary)
            {
                templateContent = templateContent.Replace($"{{{placeholder.Key}}}", placeholder.Value);
            }

            return templateContent;
        }
    }

}
