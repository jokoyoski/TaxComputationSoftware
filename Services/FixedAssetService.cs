using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.ResponseModel;
using System.Linq;
using Total = TaxComputationAPI.ResponseModel.Total;
using NetBookValue = TaxComputationAPI.ResponseModel.NetBookValue;
using TaxComputationAPI.Models;
using FixedAssetData = TaxComputationAPI.Dtos.FixedAssetData;

namespace TaxComputationAPI.Services
{
    public class FixedAssetService : IFixedAssetService
    {
        private readonly IFixedAssetRepository _fixedAssetRepository;
        private readonly ITrialBalanceRepository _trialBalanceRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly ICapitalAllowanceService _capitalAllowanceService;
        public FixedAssetService(IFixedAssetRepository fixedAssetRepository, ICapitalAllowanceService capitalAllowanceService, IUtilitiesRepository utilitiesRepository, ITrialBalanceRepository trialBalanceRepository)
        {
            _fixedAssetRepository = fixedAssetRepository;
            _trialBalanceRepository = trialBalanceRepository;
            _utilitiesRepository = utilitiesRepository;
            _capitalAllowanceService = capitalAllowanceService;
        }

        public async Task<TaxComputationAPI.Dtos.FixedAssetResponseDto> GetFixedAssetsByCompany(int companyId, int yearId)
        {
            decimal openingCostTotal = 0;
            decimal adddtionCostTotal = 0;
            decimal disposalCostTotal = 0;
            decimal closingCostTotal = 0;
            decimal openingDepreciationTotal = 0;
            decimal adddtionDepreciationTotal = 0;
            decimal disposalDepreciationTotal = 0;
            decimal closingDepreciationTotal = 0;
            decimal transferCostTotal = 0;
            decimal transferDepreciationTotal = 0;


            List<Total> totals = new List<Total>();
            List<NetBookValue> netBookValues = new List<NetBookValue>();


            var result = await _fixedAssetRepository.GetFixedAssetsByCompany(companyId, yearId);
            if (result.FixedAssetData.Count <= 0)
            {
                return null;
            }


            foreach (var x in result.FixedAssetData)
            {
                openingCostTotal += x.OpeningCost;
                adddtionCostTotal += x.CostAddition;
                disposalCostTotal += x.CostDisposal;
                closingCostTotal += await _utilitiesRepository.GetAmount(x.Id, "cost");
                openingDepreciationTotal += x.OpeningDepreciation;
                adddtionDepreciationTotal += x.DepreciationAddition;
                disposalDepreciationTotal += x.DepreciationDisposal;
                closingDepreciationTotal += await _utilitiesRepository.GetAmount(x.Id, "depreciation");
                transferCostTotal += x.TransferCost;
                transferDepreciationTotal = x.TransferDepreciation;

                netBookValues.Add(new NetBookValue
                {
                    value = await _utilitiesRepository.GetAmount(x.Id, "cost") - await _utilitiesRepository.GetAmount(x.Id, "depreciation")
                });


            }
            result.total = new Total
            {
                OpeningCostTotal = openingCostTotal,
                AdditionCostTotal = adddtionCostTotal,
                ClosingCostTotal = closingCostTotal,
                DisposalCostTotal = disposalCostTotal,
                OpeningDepreciationTotal = openingDepreciationTotal,
                AdditionDepreciationTotal = adddtionDepreciationTotal,
                DisposalDepreciationTotal = disposalDepreciationTotal,
                ClosingDepreciationTotal = closingDepreciationTotal,


            };
            result.netBookValue = netBookValues;

            return await FormatAmount(result);
        }

        public async Task SaveFixedAsset(CreateFixedAssetDto fixedAsset)
        {
            GetMappedDetails getMappedDetails = new GetMappedDetails();

            var yearRecord = await _utilitiesRepository.GetFinancialYearAsync(fixedAsset.YearId);
            if (yearRecord == null)
            {
                var createYear = new FinancialYear
                {
                    Name = fixedAsset.YearId
                };
                await _utilitiesRepository.AddFinancialYearAsync(createYear);
            }
            if (fixedAsset.TriBalanceId.Count > 0)
            {

                foreach (var value in fixedAsset.TriBalanceId)
                {
                    string trialBalanceValue = getMappedDetails.MappedTo("fixedasset");
                    await _trialBalanceRepository.UpdateTrialBalance(value, trialBalanceValue, false);

                }

                var result = await _fixedAssetRepository.SaveFixedAsset(fixedAsset);
                if (fixedAsset.IsCost)
                {
                    await _capitalAllowanceService.SaveCapitalAllowanceFromFixedAsset(fixedAsset.CostAddition, fixedAsset.YearId.ToString(), fixedAsset.CompanyId, fixedAsset.AssetId);

                }

                var record = await _fixedAssetRepository.GetFixedAssetsByCompanyYearIdAssetId(fixedAsset.CompanyId, fixedAsset.YearId, fixedAsset.AssetId);

                foreach (var value in fixedAsset.TriBalanceId)
                {
                    var trialBalanceMapping = await _trialBalanceRepository.GetTrialBalanceMappingRecordByTrialBalanceId(value);
                    if (trialBalanceMapping == null)
                    {

                        if (fixedAsset.IsCost == true)
                        {

                            await _utilitiesRepository.AddTrialBalanceMapping(value, record.Id, "fixedasset", "cost");
                        }
                        else
                        {

                            await _utilitiesRepository.AddTrialBalanceMapping(value, record.Id, "fixedasset", "depreciation");

                        }



                    }

                }

            }
            else
            {
                var result = await _fixedAssetRepository.SaveFixedAsset(fixedAsset);
                if (fixedAsset.IsCost)
                {
                    await _capitalAllowanceService.SaveCapitalAllowanceFromFixedAsset(fixedAsset.CostAddition, fixedAsset.YearId.ToString(), fixedAsset.CompanyId, fixedAsset.AssetId);

                }

            }




        }

        /* public bool GetAmount(string type, List<int> trialBalance)
         {
             decimal totalNumber = 0;

             foreach(var j in trialBalance) {
                 totalNumber= _utilitiesRepository.GetAmount(j,"cost");
             }


         }*/


        public async Task<TaxComputationAPI.Dtos.FixedAssetResponseDto> FormatAmount(FixedAssetResponse fixedAssetResponse)
        {
            List<FixedAssetData> fixedAssetDatas = new List<FixedAssetData>();
            List<TaxComputationAPI.Dtos.NetBookValue> netBookValues = new List<TaxComputationAPI.Dtos.NetBookValue>();
            List<TaxComputationAPI.Dtos.Total> totals = new List<TaxComputationAPI.Dtos.Total>();
            decimal transferValue = 0;
            decimal transferDepreciationValue = 0;
            foreach (var asset in fixedAssetResponse.FixedAssetData)
            {
                var fixedAssetData = new FixedAssetData();
                fixedAssetData.Id = asset.Id;
                fixedAssetData.CompanyName = asset.CompanyName;
                fixedAssetData.Year = asset.Year;
                fixedAssetData.FixedAssetName = asset.FixedAssetName;
                fixedAssetData.OpeningCost = $"₦{Utilities.FormatAmount(asset.OpeningCost)}";
                fixedAssetData.CostAddition = $"₦{Utilities.FormatAmount(asset.CostAddition)}";
                fixedAssetData.CostDisposal = $"₦({Utilities.FormatAmount(asset.CostDisposal)})";
                fixedAssetData.CostClosing = $"₦{Utilities.FormatAmount(await _utilitiesRepository.GetAmount(asset.Id, "cost"))}";
                fixedAssetData.OpeningDepreciation = $"₦{Utilities.FormatAmount(asset.OpeningDepreciation)}";
                fixedAssetData.DepreciationAddition = $"₦{Utilities.FormatAmount(asset.DepreciationAddition)}";
                fixedAssetData.DepreciationDisposal = $"₦({Utilities.FormatAmount(asset.DepreciationDisposal)})";
                fixedAssetData.DepreciationClosing = $"₦{Utilities.FormatAmount(await _utilitiesRepository.GetAmount(asset.Id, "depreciation"))}";
                if (asset.IsTransferDepreciationRemoved == true)
                {
                    fixedAssetData.TransferDepreciation = $"₦({Utilities.FormatAmount(asset.TransferDepreciation)})";
                    transferDepreciationValue += -asset.TransferDepreciation;
                }
                else
                {
                    fixedAssetData.TransferDepreciation = $"₦{Utilities.FormatAmount(asset.TransferDepreciation)}";
                    transferDepreciationValue += asset.TransferDepreciation;
                }

                if (asset.IsTransferCostRemoved == true)
                {
                    fixedAssetData.TransferCost = $"₦({Utilities.FormatAmount(asset.TransferCost)})";
                    transferValue += -asset.TransferCost;
                }
                else
                {
                    fixedAssetData.TransferCost = $"₦{Utilities.FormatAmount(asset.TransferCost)}";
                    transferValue += asset.TransferCost;
                }


                fixedAssetDatas.Add(fixedAssetData);
            }

            foreach (var netbook in fixedAssetResponse.netBookValue)
            {
                netBookValues.Add(new TaxComputationAPI.Dtos.NetBookValue
                {
                    value = $"{Utilities.FormatAmount(netbook.value)}"
                });


            }

               netBookValues.Add(new TaxComputationAPI.Dtos.NetBookValue
                {
                    value = $"{Utilities.FormatAmount("29000")}"
                });



            var total = new TaxComputationAPI.Dtos.Total
            {
                OpeningCostTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.OpeningCostTotal)}",
                AdditionCostTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.AdditionCostTotal)}",
                ClosingCostTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.ClosingCostTotal)}",
                DisposalCostTotal = $"₦({Utilities.FormatAmount(fixedAssetResponse.total.DisposalCostTotal)})",
                OpeningDepreciationTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.OpeningDepreciationTotal)}",
                AdditionDepreciationTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.AdditionDepreciationTotal)}",
                DisposalDepreciationTotal = $"₦({Utilities.FormatAmount(fixedAssetResponse.total.DisposalDepreciationTotal)})",
                ClosingDepreciationTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.ClosingDepreciationTotal)}",
                TransferCostTotal = $"₦{Utilities.FormatAmount(transferValue)}",
                TransferDepreciationTotal = $"₦{Utilities.FormatAmount(transferDepreciationValue)}",

            };
            TaxComputationAPI.Dtos.FixedAssetResponseDto fixedAsset = new TaxComputationAPI.Dtos.FixedAssetResponseDto();
            fixedAsset.FixedAssetData = fixedAssetDatas;
            fixedAsset.netBookValue = netBookValues;
            fixedAsset.total = total;

            return fixedAsset;
        }

        public async Task<decimal> GetAmount(List<int> trialBalances, bool isCost)
        {
            decimal amount = 0;
            if (isCost)
            {
                foreach (var item in trialBalances)
                {
                    var value = await _trialBalanceRepository.GetTrialBalanceById(item);

                    amount += value.Debit;
                }

                return amount;
            }
            else
            {
                foreach (var item in trialBalances)
                {
                    var value = await _trialBalanceRepository.GetTrialBalanceById(item);

                    amount += value.Credit;
                }

                return amount;
            }


        }

        public async Task DeleteFixedAsset(int trialbalanceId)
        {
            await _trialBalanceRepository.UpdateTrialBalance(trialbalanceId, null, true);  //fice
            await _utilitiesRepository.DeleteTrialBalancingMapping(trialbalanceId);
        }




      


      
    }
}


