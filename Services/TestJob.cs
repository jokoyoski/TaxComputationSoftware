using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Model;

namespace TaxComputationSoftware.Services
{
    public class TestJob : IJob
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ICompaniesRepository _companyRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<TestJob> _logger;

        public TestJob(INotificationRepository notificationRepository, ICompaniesRepository companyRepository, IEmailService emailService, ILogger<TestJob> logger)
        {
            _notificationRepository = notificationRepository;
            _companyRepository = companyRepository;
            _emailService = emailService;
            _logger = logger;

        }

        public Task Execute(IJobExecutionContext context)
        {
            
            _logger.LogWarning("Testing Job");

            PreFinancialYearNotification();

            return Task.CompletedTask;
        }

        private async Task PreFinancialYearNotification()
        {
            //TODO: save list in cache and check cache before going to db
            var pre = await _notificationRepository.GetPreNotification();

            var emailList = new List<PreNotification>();

            foreach (var item in pre)
            {

                PreNotification email = default(PreNotification);

                var companyDate = item.OpeningDate.Date;//.Ticks/(10000*60000);
                //companyDate = companyDate/(60*24);
                var emailDate = DateTime.Now.AddDays(5).Date;//.Ticks/(10000*60000))/(60*24);

                if (companyDate == emailDate) 
                {
                    email = new PreNotification { Id = item.Id, CompanyId = item.CompanyId, OpeningDate = item.OpeningDate };
                }

                if (email != null) emailList.Add(email);
            }

            if (emailList != null && emailList.Any() && emailList.Count() > 0)
            {
                try
                {

                    foreach (var mail in emailList)
                    {
                        var company = await _companyRepository.GetCompanyAsync(mail.CompanyId);

                        var mg = new StringBuilder();

                        mg.Append("Hello, start preping");

                        var message = mg.ToString();

                        string toEmail = "bomana.ogoni@hotmail.com";

                        string fromEmail = "bomana.ogoni@gmail.com";

                        string subject = "Prep for Annual";

                        await _emailService.Send(toEmail, fromEmail, subject, message, null);

                        mail.OpeningDate = mail.OpeningDate.AddYears(1); 

                        await _notificationRepository.UpdatePreNotification(mail);
                    }

                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }
        }
    }
}