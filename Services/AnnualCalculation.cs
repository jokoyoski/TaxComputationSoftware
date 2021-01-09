using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationSoftware.Services
{
    [DisallowConcurrentExecution]
    public class AnnualCalculation : IJob
    {

        private readonly INotificationRepository _notificationRepository;

        private readonly IEmailService _emailService;
        public AnnualCalculation(INotificationRepository notificationRepository,IEmailService emailService)
        {
            _emailService=emailService;
            _notificationRepository = notificationRepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var pre = await _notificationRepository.GetPreNotification();
                foreach (var item in pre)
                {
                    if (DateTime.Now.Date > item.ClosingDate.Date)   // add isLockBack
                    {  //add unlock
                        await CalculateAnnualCalculation(item.CompanyId, item.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                var v = ex.Message;
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
                        if (value.Channel == Constants.BalancingAdjustmentlOCK)
                        {
                            if (value.YearsToGo == 0)
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = 10,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 10,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.BalancingAdjustementOpen,
                                    NumberOfYearsAvailable = 0


                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }
                            else
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = decimal.Parse(value.ClosingResidue),
                                    ClosingResidue = decimal.Parse(value.ClosingResidue),
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 0,
                                    YearsToGo = value.YearsToGo,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.BalancingAdjustementOpen,
                                    NumberOfYearsAvailable = value.YearsToGo

                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }

                        }
                        else if (value.Channel == Constants.FixedAssetLock)
                        {
                            if (value.YearsToGo == 0)
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = 10,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 10,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.FixedAssetOpen,
                                    NumberOfYearsAvailable = 0


                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }
                            else
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = decimal.Parse(value.ClosingResidue),
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 0,
                                    YearsToGo = value.YearsToGo,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.FixedAssetOpen,
                                    NumberOfYearsAvailable = value.YearsToGo


                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }

                        }
                        else if (value.Channel == Constants.OldBalancingAdjustmentLock)
                        {
                            if (value.YearsToGo == 0)
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = 10,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 10,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.OldBalancingAdjustmentOpen,
                                    NumberOfYearsAvailable = 0


                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }
                            else
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = decimal.Parse(value.ClosingResidue),
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 0,
                                    YearsToGo = value.YearsToGo,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.OldBalancingAdjustmentOpen,
                                    NumberOfYearsAvailable = value.YearsToGo


                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }



                        }
                        else if (value.Channel == Constants.FixedAsset)
                        {
                            var capitalAllowance = new CapitalAllowance
                            {
                                TaxYear = value.TaxYear,
                                OpeningResidue = decimal.Parse(value.ClosingResidue),
                                ClosingResidue = 0,
                                Addition = 0,
                                Annual = 0,
                                Initial = 0,
                                Disposal = 0,
                                Total = 0,
                                YearsToGo = value.YearsToGo,
                                CompanyId = companyId,
                                AssetId = item.Id,
                                CompanyCode = null,
                                Channel = Constants.FixedAssetOpen,
                                NumberOfYearsAvailable = value.YearsToGo


                            };
                            _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                            _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);




                        }
                        else if (value.Channel == Constants.FixedAssetOpen)
                        {

                            if (value.YearsToGo > 0)
                            {
                                annualValue = decimal.Parse(value.OpeningResidue) / value.YearsToGo;  //opening residual/no of years to go
                                annualValue = Math.Round(annualValue, 2);
                                total = annualValue;   //total
                                closingResidue = decimal.Parse(value.OpeningResidue) - total; //openingresidual-total


                            }
                            if (value.YearsToGo<=0 ||value.YearsToGo-1==0)
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = 10,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 10,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.FixedAssetOpen,
                                    NumberOfYearsAvailable = 0

                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }

                            else
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = closingResidue,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 0,
                                    YearsToGo = value.YearsToGo - 1,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.FixedAssetOpen,
                                    NumberOfYearsAvailable = value.YearsToGo - 1


                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }
                        }


                        else if (value.Channel == Constants.BalancingAdjustementOpen)
                        {

                            if (value.YearsToGo > 0)
                            {
                                annualValue = decimal.Parse(value.OpeningResidue) / value.YearsToGo;  //opening residual/no of years to go
                                annualValue = Math.Round(annualValue, 2);
                                total = annualValue;   //total
                                closingResidue = decimal.Parse(value.OpeningResidue) - total; //openingresidual-total


                            }
                            if (value.YearsToGo<=0 ||value.YearsToGo-1==0)
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = 10,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 10,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.BalancingAdjustementOpen,
                                    NumberOfYearsAvailable = 0

                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }

                            else
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = closingResidue,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 0,
                                    YearsToGo = value.YearsToGo - 1,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.BalancingAdjustementOpen,
                                    NumberOfYearsAvailable = value.YearsToGo - 1


                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }





                        }


                        else if (value.Channel == Constants.OldBalancingAdjustmentOpen)
                        {

                            if (value.YearsToGo > 0)
                            {
                                annualValue = decimal.Parse(value.OpeningResidue) / value.YearsToGo;  //opening residual/no of years to go
                                annualValue = Math.Round(annualValue, 2);
                                total = annualValue;   //total
                                closingResidue = decimal.Parse(value.OpeningResidue) - total; //openingresidual-total


                            }
                            if (value.YearsToGo<=0 ||value.YearsToGo-1==0)
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = 10,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 10,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.OldBalancingAdjustmentOpen,
                                    NumberOfYearsAvailable = 0

                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }

                            else
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = closingResidue,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Disposal = 0,
                                    Total = 0,
                                    YearsToGo = value.YearsToGo - 1,
                                    CompanyId = companyId,
                                    AssetId = item.Id,
                                    CompanyCode = null,
                                    Channel = Constants.OldBalancingAdjustmentOpen,
                                    NumberOfYearsAvailable = value.YearsToGo - 1


                                };
                                _notificationRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                _notificationRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            }


                         }

                      
            

                    }
                }
            }
              _notificationRepository.Lock(new Model.PreNotification
                        {
                            Id = itemId,
                            IsLocked = true
                        });

                        _notificationRepository.UpdateDeferredTaxfById(companyId);
                        _notificationRepository.UpdateLossBfById(companyId);
                        
            var companyDetails=await _notificationRepository.GetCompanyAsync(companyId);
            string text=$"This is to alert you that {companyDetails.CompanyName} annual calculation for the  end of financial year has been computed";
          _emailService.Send("jookoyoski@gmail.com","bomana.ogoni@gmail.com","End of Financial Year Calculation",text.ToString(),"");

        }


        private string ChannelType(object channel)
        {
            if (channel == Constants.FixedAssetOpen)
            {
                return Constants.FixedAssetClosed;
            }
            if (channel == Constants.FixedAssetLock)
            {
                return Constants.FixedAssetClosed;
            }

            if (channel == Constants.BalancingAdjustementOpen)
            {
                return Constants.BalancingAdjustementClosed;
            }
            if (channel == Constants.BalancingAdjustmentlOCK)
            {
                return Constants.BalancingAdjustementClosed;
            }
            if (channel == Constants.OldBalancingAdjustmentOpen)
            {
                return Constants.OldBalancingAdjustmenClosed;
            }
            if (channel == Constants.OldBalancingAdjustmentLock)
            {
                return Constants.OldBalancingAdjustmenClosed;
            }
            return null;
        }
    }
}
