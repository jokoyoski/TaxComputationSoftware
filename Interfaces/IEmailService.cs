

using System.Threading.Tasks;

namespace TaxComputationSoftware.Interfaces
{
    public interface IEmailService
    {
        Task Send(string toEmail, string fromEmail,
                               string subject, string plainMessage, 
                               string htmlMessage, string toName = "", string fromName = "");
    }
}