using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Services
{
    public class MailManagerService : IMailManagerService
    {
        public async Task<bool> SendEmail(string subject, string email, string body, string key)
        {
            var client = new SendGridClient(key);
            var from = new EmailAddress("bomana.ogoni@gmail.com", "Tax Computation Software");
            var Subject = subject;
            var to = new EmailAddress(email);
            var Body = body;
            var message = MailHelper.CreateSingleEmail(from, to, subject, body, "");

            var response = await client.SendEmailAsync(message);
            var j = response.StatusCode.ToString();
            if (j == "Accepted")
            {
                return true;
            }
            return false;

        }

        public async Task SendEmail(int CompanyId, string message, string key)
        {
            var client = new SendGridClient(key);
            var from = new EmailAddress("olumideodusote@gmail.com", "Tax Computation Software");
            var subject = message;
            var to = new EmailAddress("olumideodusote@kkc-ps.com", "Olumide Odusote");
            
        }

        public async Task SendEmail(string message, string key)
        {
            var client = new SendGridClient(key);
            var from = new EmailAddress("olumideodusote@gmail.com", "Tax Computation Software");
            var subject = message;
            var to = new EmailAddress("olumideodusote@kkc-ps.com", "Olumide Odusote");
        }
    }
}
