// using System;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Logging;
// using SendGrid;
// using SendGrid.Helpers.Mail;
// using TaxComputationSoftware.Factory;
// using TaxComputationSoftware.Interfaces;

// namespace TaxComputationSoftware.Services
// {
//     public class EmailService : IEmailService
//     {
//         private readonly ILogger<EmailService> _logger;

//         public EmailService(ILogger<EmailService> logger)
//         {
//             _logger = logger;
//         }

//         public async Task Send(string toEmail, string fromEmail,
//                                string subject, string plainMessage, 
//                                string htmlMessage, string toName = "", string fromName = "")
//         {

//             try
//             {
//                 var apiKey = "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";
//                 var client = new SendGridClient(apiKey);
//                 var from = new EmailAddress(fromEmail, fromName);
//                 var to = new EmailAddress(toEmail, toName);

//                 var msg = MailHelper.CreateSingleEmail(from, to, subject, plainMessage, htmlMessage);

//                 _logger.LogInformation("Sending Email");

//                 await client.SendEmailAsync(msg);
//             }
//             catch (Exception e)
//             {
//                 _logger.LogError("Sending Email failed");
//             }

//         }

//     }
// }



using System;
using System.Threading.Tasks;
using TaxComputationSoftware.Factory;
using TaxComputationSoftware.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Logging;

namespace TaxComputationSoftware.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        const string FromEmail = "bomana.ogoni@gmail.com";
        const string FromName = "Bomanaziba Ogoni";
        public static string _toEmail { get; set; } = "azibaalpha@gmail.com";
        public static string _toName { get; set; } = "Email Sample";

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task<Response> OpeningDateEmail(string companyName, DateTime openingDate)
        {
            IEmailTemplate opening = new OpenDateEmailFactory(companyName, openingDate);
            return await Execute(opening);
        }

        public async Task<Response> ClosingDateEmail(string companyName, DateTime closingDate)
        {
            IEmailTemplate closing = new OpenDateEmailFactory(companyName, closingDate);
            return await Execute(closing);
        }

        public async Task<Response> PreNotificationEmail(string companyName, DateTime preNotificationDate)
        {
            IEmailTemplate pre = new PreNotificationEmailFactory(companyName, preNotificationDate);
            return await Execute(pre);
        }

        public async Task<Response> PostNotificationEmail(string companyName, DateTime postNotificationDate)
        {
            IEmailTemplate post = new PreNotificationEmailFactory(companyName, postNotificationDate);
            return await Execute(post);
        }

        public async Task<Response> ExceptionEmail(string method, string errorMessage)
        {
            IEmailTemplate exception = new ExceptionEmailFactory(method, errorMessage);
            return await Execute(exception);
        }

        private async Task<Response> Execute(IEmailTemplate _template)
        {
            try
            {
                const string apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(FromEmail, FromName);
                var to = new EmailAddress(_toEmail, _toName);

                var item = _template.Template();

                if(string.IsNullOrEmpty(item.HtmlContent)) item.HtmlContent = null;

                var msg = MailHelper.CreateSingleEmail(from, to, item.Subject, item.PlainTextContent, item.HtmlContent);

                var response = await client.SendEmailAsync(msg);

                return response;
            }
            catch (Exception e)
            {
                _logger.LogError("Sending Email failed: {0}", e.Message);
                throw e;
            }
        }
    }
}