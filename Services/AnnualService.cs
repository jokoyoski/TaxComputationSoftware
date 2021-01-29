using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationSoftware.Services
{
    [DisallowConcurrentExecution]
    public class AnnualService : IJob
    {

        private readonly INotificationRepository _notificationRepository;

        private readonly IEmailService _emailService;
        private readonly ILogger<AnnualService> _logger;

        public AnnualService(INotificationRepository notificationRepository, IEmailService emailService, 
                            ILogger<AnnualService> logger)
        {
            _emailService = emailService;
            _logger = logger;
            _notificationRepository = notificationRepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var pre = await _notificationRepository.GetPreNotification();
                foreach (var item in pre)
                {
                    if (DateTime.Now.Date == item.ClosingDate.Date && !item.IsLocked)
                    {  //add unlock
                        UnlockCapitalAllowance(item.CompanyId, item.Id);
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

        public async Task UnlockCapitalAllowance(int companyId, int Id)
        {
            try
            {
                var assetClasses = await _notificationRepository.GetAssetMappingAsync();
                foreach (var item in assetClasses)
                {
                    var values = await _notificationRepository.GetCapitalAllowance(item.Id, companyId);
                    var record = GetCapitalAllowance(values.ToList());
                    if (record.capitalAllowances.Count > 0)
                    {
                        foreach (var value in record.capitalAllowances)
                        {
                            string channel = "";
                            if (value.Channel.ElementAt(0) == 'F')
                            {
                                channel = Constants.FixedAssetOpen;
                            }
                            if (value.Channel.ElementAt(0) == 'B')
                            {
                                channel = Constants.BalancingAdjustementOpen;
                            }
                            if (value.Channel.ElementAt(0) == 'O')
                            {
                                channel = Constants.OldBalancingAdjustmentOpen;
                            }
                            await _notificationRepository.UpdateCapitalAllowanceForChannel(channel, value.Id);
                            await _notificationRepository.UpdateArchivedCapitalAllowanceForChannel(channel, value.CompanyId, value.TaxYear, item.Id);
                            _notificationRepository.Lock(new Model.PreNotification
                            {
                                Id = Id,
                                IsLocked = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }



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
                        TaxYear = x.TaxYear,
                        OpeningResidue = $"₦{Utilities.FormatAmount(x.OpeningResidue)}",
                        Addition = $"₦{Utilities.FormatAmount(x.Addition)}",
                        Disposal = $"₦{Utilities.FormatAmount(x.Disposal)}",
                        Initial = $"₦{Utilities.FormatAmount(x.Initial)}",
                        Annual = $"₦{Utilities.FormatAmount(x.Annual)}",
                        Total = $"₦{Utilities.FormatAmount(x.Total)}",
                        YearsToGo = x.YearsToGo,
                        NumberOfYearsAvailable = x.NumberOfYearsAvailable,
                        ClosingResidue = $"₦{Utilities.FormatAmount(x.ClosingResidue)}",
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
    }

}
