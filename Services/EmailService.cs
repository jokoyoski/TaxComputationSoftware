using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationSoftware.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task Send(string toEmail, string fromEmail,
                               string subject, string plainMessage, 
                               string htmlMessage, string toName = "", string fromName = "")
        {

            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(fromEmail, fromName);
                var to = new EmailAddress(toEmail, toName);

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainMessage, htmlMessage);

                _logger.LogInformation("Sending Email");

                await client.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                _logger.LogError("Sending Email failed");
            }

        }

    }
}