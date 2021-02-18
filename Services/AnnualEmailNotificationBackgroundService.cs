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
        private readonly IServiceProvider _services;
        private readonly ILogger<AnnualEmailNotificationBackgroundService> _logger;
        public const int AnnualJob = 48;
        public const int EmailDay = 2;
        public static string AdminEmail = "bomana.ogoni@gmail.com";
        public static string LogEmail = "azibaalpha@gmail.com";
        private Timer _timer;

        public AnnualEmailNotificationBackgroundService(IServiceProvider services, ILogger<AnnualEmailNotificationBackgroundService> logger)
        {
            _services = services;
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

                var pre = await GetPreNotificationScopedService();

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

                        await UpdatePreNotificationScopedService(mail);

                        mail.IsLocked = false;

                        await LockPreNotificationScopedService(mail);

                        var company = await GetCompanyAsyncScopedService(mail.CompanyId);

                        var date = mail.ClosingDate.AddDays(AnnualJob + 1);

                        _toEmail = "Aziba Alpha";
                        _toName = "azibaalpha@gmail.com";

                        await PreNotificationEmailScopedService(company.CompanyName, date);

                        int month = mail.OpeningDate.Month;
                        int year = mail.OpeningDate.Year;
                        int tax = mail.ClosingDate.AddYears(1).Year;
                        int financialYear = mail.ClosingDate.Year;

                        await AddFinancialYearAsyncScopedService(new FinancialYear { Name = $"{tax}", CompanyId = company.Id, OpeningDate = mail.OpeningDate, ClosingDate = mail.ClosingDate, FinancialDate = financialYear.ToString() });

                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                await ExceptionEmailScopedService(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        #region Prenotification Repository Scoped Service
        private async Task<List<PreNotification>> GetPreNotificationScopedService()
        {
            _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<INotificationRepository>();

                return await scopedProcessingService.GetPreNotification();
            }
        }

        private async Task UpdatePreNotificationScopedService(PreNotification preNotification)
        {
            _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<INotificationRepository>();

                await scopedProcessingService.UpdatePreNotification(preNotification);
            }
        }

        private async Task LockPreNotificationScopedService(PreNotification preNotification)
        {
            _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<INotificationRepository>();

                await scopedProcessingService.Lock(preNotification);
            }
        }
        #endregion

        #region Company Scoped Service
        private async Task<Company> GetCompanyAsyncScopedService(int companyId)
        {
            _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<ICompaniesService>();

                return await scopedProcessingService.GetCompanyAsync(companyId);
            }
        }
        #endregion

        #region Email Notification Scoped Service
        private async Task PreNotificationEmailScopedService(string companyName, DateTime date)
        {
            _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IEmailService>();
                await scopedProcessingService.PreNotificationEmail(companyName, date);
            }
        }
        private async Task ExceptionEmailScopedService(string methodName, string errorMessage)
        {
            _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IEmailService>();
                await scopedProcessingService.ExceptionEmail(methodName, errorMessage);
            }
        }
        #endregion

        #region Utility Notification Service Scoped
        private async Task AddFinancialYearAsyncScopedService(FinancialYear financialYear)
        {
            _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IUtilitiesRepository>();
                await scopedProcessingService.AddFinancialYearAsync(financialYear);
            }
        }
        #endregion
    }
}