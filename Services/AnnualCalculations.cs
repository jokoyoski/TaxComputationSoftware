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
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationSoftware.Services
{
    public class AnnualCalculations : IHostedService, IDisposable
    {

         private readonly INotificationRepository _notificationRepository;

        private readonly IEmailService _emailService;
        private readonly ILogger<INotificationRepository> _logger;

        public AnnualCalculations(INotificationRepository notificationRepository,IEmailService emailService, ILogger<INotificationRepository> logger)
        {
            _emailService=emailService;
            _logger = logger;
            _notificationRepository = notificationRepository;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
             try
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
            catch (Exception ex)
            {
                var v = ex.Message;

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }


        }



         public async Task CalculateAnnualCalculation(int companyId, int itemId)
        {
            decimal annualValue = 0;
            decimal total = 0;
            decimal closingResidue = 0;
            var assetClasses = await _notificationRepository.GetAssetMappingAsync();
            foreach (var item in assetClasses)
            {
                var values = await _notificationRepository.GetCapitalAllowance(item.Id, companyId);
                var record = GetCapitalAllowance(values.ToList());
                if (record.capitalAllowances.Count > 0)
                {
                    foreach (var value in record.capitalAllowances)
                    {
                        
                    
                         

                      
            

                    }
                }
            }
             
                        
            var companyDetails=await _notificationRepository.GetCompanyAsync(companyId);
            string text=$"This is to alert you that {companyDetails.CompanyName} annual calculation for the  end of financial year has been computed";
         // _emailService.Send("jookoyoski@gmail.com","bomana.ogoni@gmail.com","End of Financial Year Calculation",text.ToString(),"");

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
                        CompanyId = x.CompanyId
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




        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}