using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Interfaces
{
    public interface IMailManagerService
    {
        Task<bool> SendEmail(string subject, string email, string body, string key);
        Task SendEmail(int companyId, string message, string key);

        Task SendEmail(string message, string key);
    }
}
