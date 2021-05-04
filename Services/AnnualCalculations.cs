using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;
using TaxComputationSoftware.Model;
using Microsoft.Extensions.DependencyInjection;

namespace TaxComputationSoftware.Services
{
    public class AnnualCalculations : IHostedService, IDisposable
    {
        private readonly IServiceProvider _services;
        private readonly INotificationRepository _notificationRepository;

        private readonly IEmailService _emailService;
        private readonly ILogger<INotificationRepository> _logger;

        private Timer _timer;
        public AnnualCalculations(IServiceProvider services, INotificationRepository notificationRepository, IEmailService emailService,
                                    ILogger<INotificationRepository> logger)
        {
            // _emailService = emailService;
            _logger = logger;
            _services = services;
            _notificationRepository = notificationRepository;
        }
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(Calc, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(2));

            return Task.CompletedTask;
        }


        private async void Calc(object state)
        {
            var pre = await _notificationRepository.GetPreNotification();
            foreach (var item in pre)
            {
                if (DateTime.Now.Date == item.ClosingDate.Date)   // add isLockBack
                {  //add unlock

                    await CalculateAnnualCalculation(item.CompanyId, item.Id);
                }
            }
        }



        public async Task CalculateAnnualCalculation(int companyId, int itemId)
        {
            decimal annualValue = 0;
            decimal total = 0;
            decimal closingResidue = 0;
            var assetClasses = await _notificationRepository.GetAssetMappingAsync();

            //New Line
            var company = await GetCompanyAsyncScopedService(companyId);

            foreach (var item in assetClasses)
            {
                var values = await _notificationRepository.GetCapitalAllowance(item.Id, companyId);
                var record = GetCapitalAllowance(values.ToList());
                if (record.capitalAllowances.Count > 0)
                {
                    foreach (var value in record.capitalAllowances)
                    {
                        if (value.Channel == Constants.FixedAsset)
                        {
                            var capitalAllowance = new CapitalAllowance
                            {
                                TaxYear = value.TaxYear,
                                OpeningResidue = decimal.Parse(value.ClosingResidue),
                                ClosingResidue = 0,
                                Addition = 0,
                                Disposal = 0,
                                Annual = 0,
                                Initial = 0,
                                Total = 0,
                                YearsToGo = 0,
                                CompanyId = companyId,
                                AssetId = value.AssetId,
                                CompanyCode = value.CompanyCode,
                                Channel = Constants.OpenOld,
                                NumberOfYearsAvailable = value.YearsToGo

                            };
                            await _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                            await _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            SaveCapitalAllowanceSummary(value.AssetId, companyId);


                        }

                        if (value.Channel == Constants.Closed)
                        {

                           
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = decimal.Parse(value.ClosingResidue),
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Disposal = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Total = 0,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = value.AssetId,
                                    CompanyCode = value.CompanyCode,
                                    Channel = Constants.OpenOld,
                                    NumberOfYearsAvailable = value.YearsToGo

                                };
                                await _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                await _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                                await SaveCapitalAllowanceSummary(value.AssetId, companyId);
                            
                        }




                        if (value.Channel == Constants.OpenOld)
                        {
                        

                            var annual = decimal.Parse(value.OpeningResidue) / value.NumberOfYearsAvailable;
                            annual = Math.Round(annual, 2);
                            var totalValue = annual;
                            var closingResidueValue = decimal.Parse(value.OpeningResidue) - totalValue;
                            var yearsAvailable = value.NumberOfYearsAvailable - 1;
                            if (yearsAvailable <= 0)
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = 10,
                                    ClosingResidue = 20,
                                    Addition = 0,
                                    Disposal = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Total = 0,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = value.AssetId,
                                    CompanyCode = value.CompanyCode,
                                    Channel = Constants.Zero,
                                    NumberOfYearsAvailable = 0

                                };

                                await _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                await _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                                await SaveCapitalAllowanceSummary(value.AssetId, companyId);
                            }
                            else
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = closingResidueValue,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Disposal = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Total = 0,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = value.AssetId,
                                    CompanyCode = value.CompanyCode,
                                    Channel = Constants.OpenOld,
                                    NumberOfYearsAvailable = yearsAvailable

                                };
                                await _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                await _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                                await SaveCapitalAllowanceSummary(value.AssetId, companyId);
                            }
                        }

                    }
                }


            }
            //New Line
            company.OpeningYear = company.OpeningYear.AddYears(1);
            company.ClosingYear = company.ClosingYear.AddYears(1);

            int tax = company.ClosingYear.AddYears(1).Year;
            int financialYear = company.ClosingYear.Year;

            //TODO: Lazy man work: create a new repo method to query single pernotification database object
            var prenotification = await GetPreNotificationScopedService();
            var single = prenotification.Where(p => p.CompanyId == companyId).FirstOrDefault();

            await UpdateCompanyAsyncScopedService(company);
            await AddFinancialYearAsyncScopedService(new FinancialYear { Name = $"{tax}", CompanyId = company.Id, OpeningDate = company.OpeningYear, ClosingDate = company.ClosingYear, FinancialDate = financialYear.ToString() });
            await UpdatePreNotificationScopedService(new PreNotification { Id = single.Id, CompanyId = company.Id, OpeningDate = company.OpeningYear, ClosingDate = company.ClosingYear });



            var companyDetails = await _notificationRepository.GetCompanyAsync(companyId);
            string text = $"This is to alert you that {companyDetails.CompanyName} annual calculation for the  end of financial year has been computed";
        }

        private CapitalAllowanceDto GetCapitalAllowance(List<CapitalAllowance> capitalAllowances)
        {
            var capitalAllowanceList = new List<CapitalAllowanceViewDto>();
            if (capitalAllowances.Count > 0)
            {
                var capitalAllowanceDto = new CapitalAllowanceDto();
                var capitalAllowance = new CapitalAllowance();
                decimal openingResidualTotal = 0;
                decimal disposalTotal = 0;
                decimal initialTotal = 0;
                decimal annualTotal = 0;
                decimal totalTotal = 0;
                decimal closingResidueTotal = 0;
                decimal additionTotal = 0;
                foreach (var item in capitalAllowances)
                {

                    if (item.OpeningResidue > 0)
                    {
                        openingResidualTotal += Utilities.GetDecimal(item.OpeningResidue);
                    }

                    if (item.Addition > 0)
                    {
                        additionTotal += Utilities.GetDecimal(item.Addition);
                    }

                    if (item.Disposal > 0)
                    {
                        disposalTotal += Utilities.GetDecimal(item.Disposal);
                    }
                    if (item.Initial > 0)
                    {
                        initialTotal += Utilities.GetDecimal(item.Initial);
                    }
                    if (item.Annual > 0)
                    {
                        annualTotal += Utilities.GetDecimal(item.Annual);
                    }
                    if (item.Total > 0)
                    {
                        totalTotal += Utilities.GetDecimal(item.Total);
                    }
                    if (item.ClosingResidue > 0)
                    {
                        closingResidueTotal += Utilities.GetDecimal(item.ClosingResidue);
                    }

                }
                foreach (var x in capitalAllowances)
                {
                    var m = new CapitalAllowanceViewDto
                    {
                        Id = x.Id,
                        TaxYear = x.YearId,
                        OpeningResidue = x.OpeningResidue.ToString(),
                        Addition = x.Addition.ToString(),
                        Disposal = x.Disposal.ToString(),
                        Initial = x.Initial.ToString(),
                        Annual = x.Addition.ToString(),
                        Total = x.Total.ToString(),
                        YearsToGo = x.YearsToGo,
                        NumberOfYearsAvailable = x.NumberOfYearsAvailable,
                        ClosingResidue = x.ClosingResidue.ToString(),
                        Channel = x.Channel,
                        CompanyId = x.CompanyId,
                        AssetId = x.AssetId,
                        CompanyCode = x.CompanyCode
                    };
                    capitalAllowanceList.Add(m);
                }

                return new CapitalAllowanceDto()
                {
                    OpeningResidualTotal = openingResidualTotal,
                    AdditionTotal = additionTotal,
                    DisposalTotal = disposalTotal,
                    InitialTotal = initialTotal,
                    AnnualTotal = annualTotal,
                    TotalTotal = totalTotal,
                    ClosingResidueTotal = closingResidueTotal,
                    capitalAllowances = capitalAllowanceList




                };
            }
            else
            {
                return new CapitalAllowanceDto()
                {
                    capitalAllowances = new List<CapitalAllowanceViewDto>()
                };
            }




        }


        public async Task SaveCapitalAllowanceSummary(int assetId, int companyId)
        {
            decimal openingResidue = 0;
            decimal addition = 0;
            decimal initial = 0;
            decimal annual = 0;
            decimal total = 0;
            decimal closingResidue = 0;
            decimal disposal = 0;
            var value = await _notificationRepository.GetCapitalAllowance(assetId, companyId);
            if (value.Count() > 0)
            {

                foreach (var v in value)
                {
                    openingResidue += v.OpeningResidue;
                    addition += v.Addition;
                    initial += v.Initial;
                    annual += v.Annual;
                    total += v.Total;
                    closingResidue += v.ClosingResidue;
                    disposal += v.Disposal;
                }

                _notificationRepository.SaveCapitaLAllowanceSummary(new CapitalAllowanceSummary
                {

                    OpeningResidue = openingResidue,
                    Addition = addition,
                    Initial = initial,
                    Annual = annual,
                    Total = total,
                    ClosingResidue = closingResidue,
                    Disposal = disposal,
                    AssetId = assetId,
                    CompanyId = companyId


                });
            }

        }

        public async Task DeleteCapitalAllowanceById(int capitalAllowanceId)
        {

            var itemToDelete = await _notificationRepository.GetCapitalAllowanceById(capitalAllowanceId);
            var value = _notificationRepository.DeleteCapitalAllowanceByAssetIdCompanyIdYearId(itemToDelete.CompanyId, int.Parse(itemToDelete.TaxYear), itemToDelete.AssetId);
            _notificationRepository.DeleteCapitalAllowanceSummaryById(itemToDelete.AssetId, itemToDelete.CompanyId);
            SaveCapitalAllowanceSummary(itemToDelete.AssetId, itemToDelete.CompanyId);


        }




        public async Task<List<CapitalAllowanceSummaryDto>> GetCapitalAllowanceSummaryByCompanyId(int companyId)
        {


            List<CapitalAllowanceSummaryDto> values = new List<CapitalAllowanceSummaryDto>();
            var item = await _notificationRepository.GetCapitalAllowanceSummaryByCompanyId(companyId);
            if (item.Count() == 0)
            {
                return null;
            }
            decimal openingResidue = 0;
            decimal addition = 0;
            decimal disposal = 0;
            decimal initial = 0;
            decimal annual = 0;
            decimal total = 0;
            decimal closingResidue = 0;
            foreach (var value in item)
            {
                openingResidue += value.OpeningResidue;
                addition += value.Addition;
                disposal += value.Disposal;
                initial += value.Initial;
                annual += value.Annual;
                total += value.Total;
                closingResidue += value.ClosingResidue;

                values.Add(new CapitalAllowanceSummaryDto
                {
                    Description = value.AssetName,
                    OpeningResidue = $"₦{Utilities.FormatAmount(value.OpeningResidue)}",
                    Addition = $"₦{Utilities.FormatAmount(value.Addition)}",
                    DisposalOrTransfer = $"₦{Utilities.FormatAmount(value.Disposal)}",
                    Initial = $"₦{Utilities.FormatAmount(value.Initial)}",
                    Annual = $"₦{Utilities.FormatAmount(value.Annual)}",
                    Total = $"₦{Utilities.FormatAmount(value.Total)}",
                    ClosingResidue = $"₦{Utilities.FormatAmount(value.ClosingResidue)}",
                });

            }

            values.Add(new CapitalAllowanceSummaryDto
            {
                Description = "Total",
                OpeningResidue = $"₦{Utilities.FormatAmount(openingResidue)}",
                Addition = $"₦{Utilities.FormatAmount(addition)}",
                DisposalOrTransfer = $"₦{Utilities.FormatAmount(disposal)}",
                Initial = $"₦{Utilities.FormatAmount(initial)}",
                Annual = $"₦{Utilities.FormatAmount(annual)}",
                Total = $"₦{Utilities.FormatAmount(total)}",
                ClosingResidue = $"₦{Utilities.FormatAmount(closingResidue)}",
            });

            return values;
        }



        public async Task<decimal> GetCapitalAllowanceSummaryForIncomeTax(int companyId)
        {


            List<CapitalAllowanceSummaryDto> values = new List<CapitalAllowanceSummaryDto>();
            var item = await _notificationRepository.GetCapitalAllowanceSummaryByCompanyId(companyId);
            if (item.Count() == 0)
            {
                return 0;
            }
            decimal openingResidue = 0;
            decimal addition = 0;
            decimal disposal = 0;
            decimal initial = 0;
            decimal annual = 0;
            decimal total = 0;
            decimal closingResidue = 0;
            foreach (var value in item)
            {

                total += value.Total;
            }

            return total;

        }

        #region 
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

        private async Task UpdateCompanyAsyncScopedService(Company company)
        {
            _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<ICompaniesRepository>();

                await scopedProcessingService.UpdateCompanyDate(company);
            }
        }

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
        #endregion

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}