using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Model;
using static TaxComputationSoftware.Services.EmailService;

namespace TaxComputationSoftware.Services
{

    public class AnnualEmailNotificationBackgroundService : IHostedService, IDisposable
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly ICompaniesRepository _companyRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<AnnualEmailNotificationBackgroundService> _logger;
        public const int AnnualJob = 48;
        public const int EmailDay = 2;
        public static string AdminEmail = "bomana.ogoni@gmail.com";
        public static string LogEmail = "azibaalpha@gmail.com";
        private Timer _timer;

        public AnnualEmailNotificationBackgroundService(INotificationRepository notificationRepository, 
                                                        IUtilitiesRepository utilitiesRepository, ICompaniesRepository companyRepository, 
                                                        IEmailService emailService, ILogger<AnnualEmailNotificationBackgroundService> logger)
        {
            _notificationRepository = notificationRepository;
            _utilitiesRepository = utilitiesRepository;
            _companyRepository = companyRepository;
            _emailService = emailService;
            _logger = logger;

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(PreFinancialYearNotification, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async void PreFinancialYearNotification(object state)
        {
            try
            {

                var pre = await _notificationRepository.GetPreNotification();

                var emailList = new List<PreNotification>();

                foreach (var item in pre)
                {

                    PreNotification email = default(PreNotification);

                    var companyDate = item.ClosingDate.AddDays(EmailDay + 1).Date;
                    var emailDate = DateTime.Now.Date;


                    if (companyDate == emailDate)
                    {
                        item.JobDate = item.OpeningDate.AddDays(AnnualJob);

                        email = new PreNotification { Id = item.Id, CompanyId = item.CompanyId, OpeningDate = item.OpeningDate, JobDate = item.JobDate };
                    }

                    if (email != null) emailList.Add(email);
                }

                if (emailList != null && emailList.Any() && emailList.Count() > 0)
                {


                    foreach (var mail in emailList)
                    {

                        mail.OpeningDate = mail.OpeningDate.AddYears(1);
                        mail.ClosingDate = mail.ClosingDate.AddYears(1);

                        await _notificationRepository.UpdatePreNotification(mail);

                        mail.IsLocked = false;

                        await _notificationRepository.Lock(mail);

                        var company = await _companyRepository.GetCompanyAsync(mail.CompanyId);

                        var date = mail.ClosingDate.AddDays(AnnualJob + 1);

                        _toEmail = "Aziba Alpha";
                        _toName = "azibaalpha@gmail.com";

                        await _emailService.PreNotificationEmail(company.CompanyName, date);
                        
                        int month = mail.OpeningDate.Month;
                        int year = mail.OpeningDate.Year;
                        int tax = mail.ClosingDate.AddYears(1).Year;

                        await _utilitiesRepository.AddFinancialYearAsync(new FinancialYear { Name = $"{tax}", CompanyId = company.Id, OpeningDate = mail.OpeningDate, ClosingDate = mail.ClosingDate });

                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}