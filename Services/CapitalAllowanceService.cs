using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Services
{
    public class CapitalAllowanceService : ICapitalAllowanceService
    {
        private readonly ICapitalAllowanceRepository _capitalAllowanceRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly ICompaniesRepository _companyRepository;
        private readonly IMemoryCache _memoryCache;

        public CapitalAllowanceService(ICapitalAllowanceRepository capitalAllowanceRepository, ICompaniesRepository companyRepository, IMemoryCache memoryCache, IUtilitiesRepository utilitiesRepository)
        {
            _capitalAllowanceRepository = capitalAllowanceRepository;
            _utilitiesRepository = utilitiesRepository;
            _companyRepository = companyRepository;
            _memoryCache = memoryCache;
        }

        public async Task<CapitalAllowanceDto> GetCapitalAllowance(int assetId, int companyId)
        {

            var capitalAllowance = await _capitalAllowanceRepository.GetCapitalAllowance(assetId, companyId);


            return GetCapitalAllowance(capitalAllowance.ToList());
        }


        public Task SaveCapitalAllowance(CapitalAllowance capitalAllowance)
        {
            capitalAllowance.Channel = Constants.OldBalancingAdjustmentOpen;
            _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance, Constants.OldBalancingAdjustmentOpen);
            _capitalAllowanceRepository.SaveCapitaLAllowance(capitalAllowance, Constants.OldBalancingAdjustmentOpen);
            SaveCapitalAllowanceSummary(capitalAllowance.AssetId, capitalAllowance.CompanyId);
            return Task.CompletedTask;

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
            decimal annualValue1 = 0;
            decimal annualValue2 = 0;
            decimal annualValue3 = 0;
            int remianingYears = 0;
            int numOfYearsAvailable = 0;

            var companyCode = await _utilitiesRepository.GetCompanyCodeByCodeId(companyId);
            var assetDetails = await _utilitiesRepository.GetAssetMappingById(assetId);
            var companyDetails = await _companyRepository.GetCompanyAsync(companyId);
            var previousRecord = await _capitalAllowanceRepository.GetCapitalAllowanceByAssetIdYear(assetId, companyId, year);


            if (disposal != 0)  //less than zero specifies that the account needs balancing aadjustmnet
            {


                closingResidue = 0;
                annual = 0;
                Initial = 0;
                total = 0;
                remianingYears = (int)100 / assetDetails.Annual;  //no of years
                code = null;
                channel = Constants.BalancingAdjustment;
                numOfYearsAvailable = remianingYears;
                disposal = 0;

            }
            else
            {
                //cos-initial/no of years* no of month used/12

                totalNoOfYears = (int)100 / assetDetails.Annual;  //no of years
                annualPercentage = (decimal)assetDetails.Annual / 100;     //annual percentage rate
                additionValue = addition;   //addittion
                Initial = addition * assetDetails.Initial / 100;     //initial=addition*%rateinitial   
                Initial = Math.Round(Initial, 2);
                annualValue1 = addition - Initial;
                annualValue2 = annualValue1 / totalNoOfYears;
                annualValue3 = annualValue2 * companyDetails.MonthOfOperation / 12;
                //value = addition - Initial;         //  
                annual = Math.Round(annualValue3, 2);   //addition-initial* %annualpercenatgerate  
                total = Initial + annual;         //total=addition-initial+total;
                closingResidue = addition - total;      //closingresidue=addition-total
                remianingYears = totalNoOfYears - 1;    //remainingyears-1
                code = "0";
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
                await _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                SaveCapitalAllowanceSummary(assetId, companyId);
                return 1;


            }
            else
            {
                await _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                await _capitalAllowanceRepository.SaveCapitaLAllowance(capitalAllowance, channel);
                SaveCapitalAllowanceSummary(assetId, companyId);
                return 1;

            }

        }


        public async Task<int> SaveCapitalAllowanceFromBalancingAdjustment(decimal residue, string year, int companyId, int assetId)
        {
            var residueValue = residue;
            var previousRecord = await _capitalAllowanceRepository.GetCapitalAllowanceByAssetIdYear(assetId, companyId, year);
            var companyCode = await _utilitiesRepository.GetCompanyCodeByCodeId(companyId);
            var companyDetails = await _companyRepository.GetCompanyAsync(companyId);

            if (previousRecord != null)
            {
                if (previousRecord.Initial <= 0 && previousRecord.Channel == Constants.OldBalancingAdjustment || previousRecord.Channel == Constants.BalancingAdjustementOpen || previousRecord.Channel == Constants.FixedAssetOpen || previousRecord.Channel == Constants.OldBalancingAdjustmentOpen)
                {
                    decimal openingResidueValue = previousRecord.OpeningResidue - residue;   //openingresidue- residue 
                    decimal annualValue = openingResidueValue / previousRecord.NumberOfYearsAvailable;  //opening residual/no of years available
                    annualValue = Math.Round(annualValue, 2);
                    decimal total = annualValue;   //total
                    decimal closingResidue = openingResidueValue - total; //openingresidual-total

                    if (previousRecord.YearsToGo - 1 == 0)
                    {
                        var capitalAllowanceRecord = new CapitalAllowance
                        {
                            TaxYear = previousRecord.TaxYear,
                            OpeningResidue = 10,
                            ClosingResidue = 0,
                            Addition = 0,
                            Annual = 0,
                            Initial = 0,
                            Disposal = 0,
                            Total = 10,
                            YearsToGo = 0,
                            CompanyId = companyId,
                            AssetId = previousRecord.AssetId,
                            CompanyCode = null,
                            Channel = Constants.OldBalancingAdjustmentOpen,
                            NumberOfYearsAvailable = 0


                        };
                        _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(previousRecord, previousRecord.Channel);
                        await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowanceRecord);
                        SaveCapitalAllowanceSummary(assetId, companyId);
                        return 1;
                    }
                    else
                    {
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
                            YearsToGo = previousRecord.YearsToGo - 1,
                            CompanyId = companyId,
                            AssetId = assetId,
                            CompanyCode = "companyCode.Code",
                            Channel = ChannelType(previousRecord.Channel),
                            NumberOfYearsAvailable = previousRecord.NumberOfYearsAvailable


                        };

                        _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(previousRecord, previousRecord.Channel);
                        await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                        SaveCapitalAllowanceSummary(assetId, companyId);
                        return 1;
                    }

                }
                else
                {
                    decimal annualValue1 = 0;
                    decimal annualValue2 = 0;
                    decimal annualValue3 = 0;
                    decimal newadditionValue = previousRecord.Addition - residue;      // new addition  =  addition-residue
                    var assetDetails = await _utilitiesRepository.GetAssetMappingById(assetId);
                    int newtotalNoOfYears = (int)100 / assetDetails.Annual;      //total no years
                    decimal annualPercentage = (decimal)assetDetails.Annual / 100;   //annual percentage value
                    decimal newInitialValue = newadditionValue * assetDetails.Initial / 100;
                    newInitialValue = Math.Round(newInitialValue, 2);
                    decimal newAnnualValue = newadditionValue - newInitialValue; // addition-initial * annual percentage
                    annualValue2 = newAnnualValue / newtotalNoOfYears;
                    annualValue3 = annualValue2 * companyDetails.MonthOfOperation / 12;
                    newAnnualValue = Math.Round(annualValue3, 2);;
                    var newTotalValue = newAnnualValue + newInitialValue;   // initial+total
                    var newClosingResidue = newadditionValue - newTotalValue;  // addition-total
                    var newRemainingyears = newtotalNoOfYears - 1;   //years to go

                    if (previousRecord.YearsToGo - 1 == 0)
                    {
                        var capitalAllowanceRecord = new CapitalAllowance
                        {
                            TaxYear = previousRecord.TaxYear,
                            OpeningResidue = 10,
                            ClosingResidue = 0,
                            Addition = 0,
                            Annual = 0,
                            Initial = 0,
                            Disposal = 0,
                            Total = 10,
                            YearsToGo = 0,
                            CompanyId = companyId,
                            AssetId = previousRecord.AssetId,
                            CompanyCode = null,
                            Channel = Constants.OldBalancingAdjustmentOpen,
                            NumberOfYearsAvailable = 0


                        };
                        _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(previousRecord, previousRecord.Channel);
                        await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowanceRecord);
                        SaveCapitalAllowanceSummary(assetId, companyId);
                        return 1;

                    }
                    else
                    {
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
                            CompanyCode = "companyCode.Code",
                            Channel = ChannelType(previousRecord.Channel),
                            NumberOfYearsAvailable = newtotalNoOfYears,


                        };
                        _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(previousRecord, previousRecord.Channel);
                        await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                        SaveCapitalAllowanceSummary(assetId, companyId);
                        return 1;


                    }



                }


            }

            return 0;

        }

        public async Task UpdateCapitalAllowanceFromDeleteBalancingAdjustment(decimal residue, string year, int companyId, int assetId)
        {
            decimal openingResidue = 0;
            var residueValue = residue;
            var previousRecord = await _capitalAllowanceRepository.GetArchivedCapitalAllowanceByAssetIdYear(assetId, companyId, year);
            if (previousRecord != null)
            {
                await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(previousRecord);
                SaveCapitalAllowanceSummary(assetId, companyId);
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

        public Task<CapitalAllowance> GetCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year)
        {
            return _capitalAllowanceRepository.GetCapitalAllowanceByAssetIdYear(assetId, companyId, year);
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
            var value = await _capitalAllowanceRepository.GetCapitalAllowance(assetId, companyId);
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

                _capitalAllowanceRepository.SaveCapitaLAllowanceSummary(new CapitalAllowanceSummary
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

            var itemToDelete = await _capitalAllowanceRepository.GetCapitalAllowanceById(capitalAllowanceId);
            var value = _capitalAllowanceRepository.DeleteCapitalAllowanceByAssetIdCompanyIdYearId(itemToDelete.CompanyId, int.Parse(itemToDelete.TaxYear), itemToDelete.AssetId);
            _capitalAllowanceRepository.DeleteCapitalAllowanceSummaryById(itemToDelete.AssetId, itemToDelete.CompanyId);
            SaveCapitalAllowanceSummary(itemToDelete.AssetId, itemToDelete.CompanyId);


        }

        public async Task<List<CapitalAllowanceSummaryDto>> GetCapitalAllowanceSummaryByCompanyId(int companyId)
        {


            List<CapitalAllowanceSummaryDto> values = new List<CapitalAllowanceSummaryDto>();
            var item = await _capitalAllowanceRepository.GetCapitalAllowanceSummaryByCompanyId(companyId);
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
            var item = await _capitalAllowanceRepository.GetCapitalAllowanceSummaryByCompanyId(companyId);
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


        public async Task<decimal> GetCapitalAllowanceSummaryForDeferredTax(int companyId)
        {


            List<CapitalAllowanceSummaryDto> values = new List<CapitalAllowanceSummaryDto>();
            var item = await _capitalAllowanceRepository.GetCapitalAllowanceSummaryByCompanyId(companyId);
            if (item.Count() == 0)
            {
                return 0;
            }


            decimal closingResidue = 0;
            foreach (var value in item)
            {

                closingResidue += value.ClosingResidue;
            }

            return closingResidue;

        }

        public Task<int> UpdateCapitalAllowanceForChannel(string channel, int Id)
        {
            return _capitalAllowanceRepository.UpdateCapitalAllowanceForChannel(channel, Id);
        }

        public Task<int> UpdateArchivedCapitalAllowanceForChannel(string channel, int companyId, string taxYear, int assetId)
        {
            return _capitalAllowanceRepository.UpdateArchivedCapitalAllowanceForChannel(channel, companyId, taxYear, assetId);
        }

        public string ChannelType(string currentChannel)
        {
            if (currentChannel == Constants.FixedAssetOpen)
            {
                return Constants.FixedAssetLock;
            }
            if (currentChannel == Constants.BalancingAdjustment)
            {
                return Constants.BalancingAdjustmentlOCK;
            }

            if (currentChannel == Constants.OldBalancingAdjustmentOpen)
            {
                return Constants.OldBalancingAdjustmentLock;
            }
            return null;

        }
    }
}
