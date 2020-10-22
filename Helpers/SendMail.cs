using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TaxComputationSoftware.Helpers
{
    public class SendMail
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
    }
}