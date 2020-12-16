using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;

namespace TaxComputationAPI.Services
{
    public class CapitalAllowanceService : ICapitalAllowanceService
    {
        private readonly ICapitalAllowanceRepository _capitalAllowanceRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;

        public CapitalAllowanceService(ICapitalAllowanceRepository capitalAllowanceRepository, IUtilitiesRepository utilitiesRepository)
        {
            _capitalAllowanceRepository = capitalAllowanceRepository;
            _utilitiesRepository = utilitiesRepository;
        }

        public async Task<CapitalAllowanceDto> GetCapitalAllowance(int assetId, int companyId)
        {

            var capitalAllowance = await _capitalAllowanceRepository.GetCapitalAllowance(assetId, companyId);


            return GetCapitalAllowance(capitalAllowance.ToList());
        }


        public Task<int> SaveCapitalAllowance(CapitalAllowance capitalAllowance)
        {
             _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance,capitalAllowance.Channel);
            return _capitalAllowanceRepository.SaveCapitaLAllowance(capitalAllowance, Constants.OldBalancingAdjustment);

        }



        public async Task<int> SaveCapitalAllowanceFromFixedAsset(decimal addition, string year, int companyId, int assetId, decimal disposal)

        {
            string channel = "";
            string code = "";
            int totalNoOfYears = 0;
            decimal annualPercentage = 0;
            decimal additionValue = 0;
            decimal Initial = 0;
            decimal value = 0;
            decimal annual = 0;
            decimal total = 0;
            decimal closingResidue = 0;
            int remianingYears = 0;
            int numOfYearsAvailable = 0;

            var companyCode = await _utilitiesRepository.GetCompanyCodeByCodeId(companyId);
            var assetDetails = await _utilitiesRepository.GetAssetMappingById(assetId);
            var previousRecord = await _capitalAllowanceRepository.GetCapitalAllowanceByAssetIdYear(assetId, companyId, year);


            if (disposal>0)  //greater than zero specifies that the account needs balancing aadjustmnet
            {


                closingResidue = 0;
                annual = 0;
                Initial = 0;
                total = 0;
                remianingYears = (int)100 / assetDetails.Annual;  //no of years
                code = null;
                channel = Constants.BalancingAdjustment;
                numOfYearsAvailable = remianingYears;
                disposal=0;

            }
            else
            {


                totalNoOfYears = (int)100 / assetDetails.Annual;  //no of years
                annualPercentage = (decimal)assetDetails.Annual / 100;     //annual percentage rate
                additionValue = addition;   //addittion
                Initial = addition * assetDetails.Initial / 100;     //initial=addition*%rateinitial
                value = addition - Initial;         //  
                annual = value * annualPercentage;   //addition-initial* %annualpercenatgerate
                total = Initial + annual;         //total=addition-initial+total;
                closingResidue = addition - total;      //closingresidue=addition-total
                remianingYears = totalNoOfYears - 1;    //remainingyears-1
                code = companyCode.Code;
                channel = Constants.FixedAsset;
                numOfYearsAvailable = totalNoOfYears;
            }




            var capitalAllowance = new CapitalAllowance
            {
                TaxYear = year,
                OpeningResidue = 0,
                ClosingResidue = closingResidue,
                Addition = addition,
                Disposal = 0,
                Annual = annual,
                Initial = Initial,
                Total = total,
                YearsToGo = remianingYears,
                CompanyId = companyId,
                AssetId = assetId,
                CompanyCode = code,
                Channel = channel,
                NumberOfYearsAvailable = numOfYearsAvailable

            };

            if (previousRecord != null)
            {
                 await  _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance,capitalAllowance.Channel);
                return await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);

            }
            else
            {
                await  _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance,capitalAllowance.Channel);
                return await _capitalAllowanceRepository.SaveCapitaLAllowance(capitalAllowance, channel);
                
            }
          
        }


        public async Task<int> SaveCapitalAllowanceFromBalancingAdjustment(decimal residue, string year, int companyId, int assetId)
        {
            //  decimal openingResidue = 0;
            var residueValue = residue;

            int yearsToGo = 0;
            var previousRecord = await _capitalAllowanceRepository.GetCapitalAllowanceByAssetIdYear(assetId, companyId, year);
            var companyCode = await _utilitiesRepository.GetCompanyCodeByCodeId(companyId);

            if (previousRecord != null)
            {
                if (previousRecord.Initial <= 0 && previousRecord.Channel == Constants.OldBalancingAdjustment)
                {
                    decimal openingResidueValue = previousRecord.OpeningResidue - residue;   //openingresidue- residue 
                    decimal annualValue = openingResidueValue / previousRecord.YearsToGo;  //opening residual/total no of years
                    annualValue = Math.Round(annualValue, 2);
                    decimal total = annualValue;   //total
                    decimal closingResidue = openingResidueValue - total; //openingresidual-total


                    var capitalAllowance = new CapitalAllowance
                    {
                        TaxYear = year,
                        OpeningResidue = previousRecord.OpeningResidue,
                        ClosingResidue = closingResidue,
                        Addition = previousRecord.Addition,
                        Annual = annualValue,
                        Initial = previousRecord.Initial,
                        Disposal = residue,
                        Total = total,
                        YearsToGo = previousRecord.NumberOfYearsAvailable - 1,
                        CompanyId = companyId,
                        AssetId = assetId,
                        CompanyCode = companyCode.Code,
                        Channel = Constants.OldBalancingAdjustmentSet,
                        NumberOfYearsAvailable = previousRecord.NumberOfYearsAvailable


                    };

                      _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(previousRecord,previousRecord.Channel);
                    return await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);

                }
                else
                {

                    decimal newadditionValue = previousRecord.Addition - residue;      // new addition  =  addition-residue
                    var assetDetails = await _utilitiesRepository.GetAssetMappingById(assetId);
                    int newtotalNoOfYears = (int)100 / assetDetails.Annual;      //total no years
                    decimal annualPercentage = (decimal)assetDetails.Annual / 100;   //annual percentage value
                    decimal newInitialValue = newadditionValue * assetDetails.Initial / 100;
                    decimal newAnnualValue = newadditionValue - newInitialValue; // addition-initial * annual percentage
                    newAnnualValue = newAnnualValue * annualPercentage;
                    var newTotalValue = newAnnualValue + newInitialValue;   // initial+total
                    var newClosingResidue = newadditionValue - newTotalValue;  // addition-total
                    var newRemainingyears = newtotalNoOfYears - 1;   //years to go

                    var capitalAllowance = new CapitalAllowance
                    {
                        TaxYear = year,
                        OpeningResidue = 0,
                        ClosingResidue = newClosingResidue,
                        Addition = previousRecord.Addition,
                        Annual = newAnnualValue,
                        Initial = newInitialValue,
                        Total = newTotalValue,
                        Disposal = residue,
                        YearsToGo = newRemainingyears,
                        CompanyId = companyId,
                        AssetId = assetId,
                        CompanyCode = companyCode.Code,
                        Channel = Constants.BalancingAdjustmentSet,
                        NumberOfYearsAvailable = newtotalNoOfYears,


                    };
                      _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(previousRecord, previousRecord.Channel);
                    return await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);


                }

              
            }

            return 0;

        }

        public async Task UpdateCapitalAllowanceFromDeleteBalancingAdjustment(decimal residue, string year, int companyId, int assetId)
        {
            decimal openingResidue = 0;
            var residueValue = residue;
            var previousRecord = await _capitalAllowanceRepository.GetArchivedCapitalAllowanceByAssetIdYear(assetId, companyId, year);
            await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(previousRecord);
            /* if (previousRecord != null)
             {
                 if (previousRecord.Initial <= 0 && previousRecord.Channel == Constants.OldBalancingAdjustment)
                 {
                     decimal openingResidueValue = previousRecord.OpeningResidue + residue;   //add residue deducted back to opening residual
                     decimal annualValue = openingResidue / previousRecord.YearsToGo;   //openingresidue/no of years to get annual
                     annualValue = Math.Round(annualValue, 2);
                     decimal total = annualValue;       //total= annualValue
                     decimal closingResidue = openingResidueValue - total;   // openng residualvalue - total
                     var capitalAllowance = new CapitalAllowance
                     {
                         TaxYear = year,
                         OpeningResidue = openingResidueValue,
                         Disposal = 0,
                         ClosingResidue = closingResidue,
                         Addition = previousRecord.Addition,
                         Annual = annualValue,
                         Initial = previousRecord.Initial,
                         Total = total,
                         YearsToGo = previousRecord.YearsToGo + 1,
                         CompanyId = companyId,
                         AssetId = assetId,
                         CompanyCode = null,
                         Channel = Constants.OldBalancingAdjustment,
                         NumberOfYearsAvailable = previousRecord.NumberOfYearsAvailable,


                     };
                     await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);

                 }
                 else
                 {

                     decimal newadditionValue = previousRecord.Addition;      // addition+ residue
                     var assetDetails = await _utilitiesRepository.GetAssetMappingById(assetId);
                     int newtotalNoOfYears = (int)100 / assetDetails.Annual;   //  get total no of years
                     decimal newInitialValue = newadditionValue * assetDetails.Initial / 100;    //initial=addition* initialrate%
                     decimal annualPercentage = (decimal)assetDetails.Annual / 100;   //annual percentage value
                     decimal newAnnualValue = newadditionValue - newInitialValue; //  addition-initial * annural%rate
                     newAnnualValue = newAnnualValue * annualPercentage;
                     var newTotalValue = newAnnualValue + newInitialValue;  //total=annual+initial
                     var newClosingResidue = newadditionValue - newTotalValue;    //closing addition-total
                     var newRemainingyears = newtotalNoOfYears - 1;     //deduct one

                     var capitalAllowance = new CapitalAllowance
                     {
                         TaxYear = year,
                         OpeningResidue = 0,
                         ClosingResidue = newClosingResidue,
                         Disposal = 0,
                         Addition = previousRecord.Addition,
                         Annual = newAnnualValue,
                         Initial = newInitialValue,
                         Total = newTotalValue,
                         YearsToGo = previousRecord.YearsToGo + 1,
                         CompanyId = companyId,
                         AssetId = assetId,
                         Channel = Constants.BalancingAdjustment,
                         CompanyCode = null,
                         NumberOfYearsAvailable = previousRecord.NumberOfYearsAvailable

                     };
                     await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);


                 }


             }*/




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
                        Id=x.Id,
                        TaxYear = x.TaxYear,
                        OpeningResidue = $"₦{Utilities.FormatAmount(x.OpeningResidue)}",
                        Addition = $"₦{Utilities.FormatAmount(x.Addition)}",
                        Disposal = $"₦{Utilities.FormatAmount(x.Disposal)}",
                        Initial = $"₦{Utilities.FormatAmount(x.Initial)}",
                        Annual = $"₦{Utilities.FormatAmount(x.Annual)}",
                        Total = $"₦{Utilities.FormatAmount(x.Total)}",
                        YearsToGo = x.YearsToGo,
                        NumberOfYearsAvailable=x.NumberOfYearsAvailable,
                        ClosingResidue = $"₦{Utilities.FormatAmount(x.ClosingResidue)}",
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
                return new CapitalAllowanceDto();
            }




        }

        public Task<CapitalAllowance> GetCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year)
        {
            return _capitalAllowanceRepository.GetCapitalAllowanceByAssetIdYear(assetId, companyId, year);
        }
    }
}
