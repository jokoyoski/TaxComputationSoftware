

using System;
using System.Threading.Tasks;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Respoonse;

namespace TaxComputationSoftware.Factory
{

    public class OpenDateEmailFactory : IEmailTemplate
    {
        private readonly string _companyName;
        private readonly DateTime _openingDate;

        public OpenDateEmailFactory(string companyName, DateTime openingDate)
        {
            _companyName = companyName;
            _openingDate = openingDate;
        }

        public EmailTemplateResponse Template()
        {
            string subject = "Opening Date";
            
            string plateMessage = "";
            string htmlMessage = "";

            return new EmailTemplateResponse 
            {
                Subject = subject,
                PlainTextContent = plateMessage,
                HtmlContent = htmlMessage
            };
        }
    }


    public class ClosingDateEmailFactory : IEmailTemplate
    {

        private readonly string _companyName;
        private readonly DateTime _closingDate;

        public ClosingDateEmailFactory(string companyName, DateTime closingDate)
        {
            _companyName = companyName;
            _closingDate = closingDate;
        }

        public EmailTemplateResponse Template()
        {
            string subject = "Closing Date";

            string plateMessage = "";
            string htmlMessage = "";

            return new EmailTemplateResponse 
            {
                Subject = subject,
                PlainTextContent = plateMessage,
                HtmlContent = htmlMessage
            };
        }
    }

    public class PreNotificationEmailFactory : IEmailTemplate
    {
        private readonly string _companyName;
        private readonly DateTime _prenotificationDate;

        public PreNotificationEmailFactory(string companyName, DateTime prenotificationDate)
        {
            _companyName = companyName;
            _prenotificationDate = prenotificationDate;
        }

        public EmailTemplateResponse Template()
        {
            string subject = "Prepare for Opening Date";

            string plateMessage = $"Hello as you all know that {_companyName} financial year has started , you are required to have done the necessary balancing adjustment on or before {_prenotificationDate.ToString("dddd, dd MMMM yyyy")}";
            string htmlMessage = "";

            return new EmailTemplateResponse 
            {
                Subject = subject,
                PlainTextContent = plateMessage,
                HtmlContent = htmlMessage
            };
        }
    }

    public class PostNotificationEmailFactory : IEmailTemplate
    {
        private readonly string _companyName;
        private readonly DateTime _postnotificationDate;

        public PostNotificationEmailFactory(string companyName, DateTime postnotificationDate)
        {
            _companyName = companyName;
            _postnotificationDate = postnotificationDate;
        }

        public EmailTemplateResponse Template()
        {
            string subject = "Post Opening Date Preparation";

            string plateMessage = "";
            string htmlMessage = "";

            return new EmailTemplateResponse 
            {
                Subject = subject,
                PlainTextContent = plateMessage,
                HtmlContent = htmlMessage
            };
        }
    }
    
    public class ExceptionEmailFactory : IEmailTemplate
    {
        private readonly string _method;
        private readonly string _errorMessage;

        public ExceptionEmailFactory(string method, string errorMessage)
        {
            _method = method;
            _errorMessage = errorMessage;
        }

        public EmailTemplateResponse Template()
        {
            string subject = "Exception Occurred";

            string plateMessage = $"{_method}: {_errorMessage}";
            string htmlMessage = "";

            return new EmailTemplateResponse 
            {
                Subject = subject,
                PlainTextContent = plateMessage,
                HtmlContent = htmlMessage
            };
        }
    }


}