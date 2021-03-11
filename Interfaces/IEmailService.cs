using System;
using System.Threading.Tasks;
using SendGrid;


namespace TaxComputationSoftware.Interfaces
{
    public interface IEmailService
    {
        Task<Response> SendPdf(byte[] records);
        Task<Response> ExceptionEmail(string method, string errorMessage);
        Task<Response> OpeningDateEmail(string companyName, DateTime openingDate);
        Task<Response> ClosingDateEmail(string companyName, DateTime closingDate);
        Task<Response> PreNotificationEmail(string companyName, DateTime preNotificationDate);
        Task<Response> PostNotificationEmail(string companyName, DateTime postNotificationDate);
    }
    
    
}