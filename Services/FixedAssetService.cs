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

        public async Task<decimal> GetFixedAssetsByCompanyForDeferredTax(int companyId, int yearId)
        {
            decimal netBookValue = 0;
            List<Total> totals = new List<Total>();
            List<NetBookValue> netBookValues = new List<NetBookValue>();
            var result = await _fixedAssetRepository.GetFixedAssetsByCompany(companyId, yearId);
            if (result.FixedAssetData.Count <= 0)
            {
                return 0;
            }
            foreach (var x in result.FixedAssetData)
            {
                decimal costValue = await _utilitiesRepository.GetAmount(x.Id, "cost");
                decimal depreciationValue = await _utilitiesRepository.GetAmount(x.Id, "depreciation"); ;
                netBookValue += costValue - depreciationValue;
                netBookValues.Add(new NetBookValue
                {
                    value = costValue - depreciationValue
                });


            }

            return netBookValue;
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
            decimal cost = 0;
            decimal depreciation = 0;

            int i = 0;


            List<Total> totals = new List<Total>();
            List<NetBookValue> netBookValues = new List<NetBookValue>();


            var result = await _fixedAssetRepository.GetFixedAssetsByCompany(companyId, yearId);
            if (result.FixedAssetData.Count <= 0)
            {
                return null;
            }

            List<decimal> costList = new List<decimal>();
            List<decimal> depreciationList = new List<decimal>();
            foreach (var x in result.FixedAssetData)
            {
                decimal costValue = await _utilitiesRepository.GetAmount(x.Id, "cost");
                decimal depreciationValue = await _utilitiesRepository.GetAmount(x.Id, "depreciation"); ;
                openingCostTotal += x.OpeningCost;
                adddtionCostTotal += x.CostAddition;
                disposalCostTotal += -x.CostDisposal;
                closingCostTotal += costValue;
                openingDepreciationTotal += x.OpeningDepreciation;
                adddtionDepreciationTotal += x.DepreciationAddition;
                disposalDepreciationTotal += -x.DepreciationDisposal;
                closingDepreciationTotal += depreciationValue;
                transferCostTotal += x.TransferCost;
                transferDepreciationTotal = x.TransferDepreciation;
                costList.Add(costValue);
                depreciationList.Add(depreciationValue);
                netBookValues.Add(new NetBookValue
                {
                    value = costValue - depreciationValue
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
            netBookValues.Add(new NetBookValue
            {
                value = closingCostTotal - closingDepreciationTotal
            });
            result.netBookValue = netBookValues;

            return await FormatAmount(result, costList.ToArray(), depreciationList.ToArray());
        }

        public async Task SaveFixedAsset(CreateFixedAssetDto fixedAsset)
        {
            string type = fixedAsset.IsCost ? "Cost" : "Depreciation";
            GetMappedDetails getMappedDetails = new GetMappedDetails();

            var assetName = await _utilitiesRepository.GetAssetMappingById(fixedAsset.AssetId);
            if (fixedAsset.TriBalanceId.Count > 0)
            {

                foreach (var value in fixedAsset.TriBalanceId)
                {


                    string trialBalanceValue = $"MAPPED TO [FIXED ASSET] {type} {assetName.AssetName}";
                    await _trialBalanceRepository.UpdateTrialBalance(value, trialBalanceValue, false);

                }

                var result = await _fixedAssetRepository.SaveFixedAsset(fixedAsset);
                if (fixedAsset.IsCost)
                {
                    await _capitalAllowanceService.SaveCapitalAllowanceFromFixedAsset(fixedAsset.CostAddition, fixedAsset.YearId.ToString(), fixedAsset.CompanyId, fixedAsset.AssetId, fixedAsset.CostDisposal);

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
                if (fixedAsset.CostDisposal == -1)
                {
                    fixedAsset.CostDisposal = 0;
                }
                var result = await _fixedAssetRepository.SaveFixedAsset(fixedAsset);
                if (fixedAsset.IsCost)
                {
                    await _capitalAllowanceService.SaveCapitalAllowanceFromFixedAsset(fixedAsset.CostAddition, fixedAsset.YearId.ToString(), fixedAsset.CompanyId, fixedAsset.AssetId, fixedAsset.CostDisposal);

                }

            }




        }



        public async Task<TaxComputationAPI.Dtos.FixedAssetResponseDto> FormatAmount(FixedAssetResponse fixedAssetResponse, decimal[] cost, decimal[] depreciation)
        {
            List<FixedAssetData> fixedAssetDatas = new List<FixedAssetData>();
            List<TaxComputationAPI.Dtos.NetBookValue> netBookValues = new List<TaxComputationAPI.Dtos.NetBookValue>();
            List<TaxComputationAPI.Dtos.Total> totals = new List<TaxComputationAPI.Dtos.Total>();
            decimal transferValue = 0;
            decimal transferDepreciationValue = 0;
            int i = 0;
            foreach (var asset in fixedAssetResponse.FixedAssetData)
            {
                var fixedAssetData = new FixedAssetData();
                fixedAssetData.Id = asset.Id;
                fixedAssetData.CompanyName = asset.CompanyName;
                fixedAssetData.Year = asset.Year;
                fixedAssetData.FixedAssetName = asset.FixedAssetName;
                fixedAssetData.OpeningCost = $"₦{Utilities.FormatAmount(asset.OpeningCost)}";
                fixedAssetData.CostAddition = $"₦{Utilities.FormatAmount(asset.CostAddition)}";
                fixedAssetData.CostDisposal = $"₦{Utilities.FormatAmount(-asset.CostDisposal)}";
                fixedAssetData.CostClosing = $"₦{Utilities.FormatAmount(cost[i])}";
                fixedAssetData.OpeningDepreciation = $"₦{Utilities.FormatAmount(asset.OpeningDepreciation)}";
                fixedAssetData.DepreciationAddition = $"₦{Utilities.FormatAmount(asset.DepreciationAddition)}";
                fixedAssetData.DepreciationDisposal = $"₦{Utilities.FormatAmount(-asset.DepreciationDisposal)}";
                fixedAssetData.DepreciationClosing = $"₦{Utilities.FormatAmount(depreciation[i])}";
                if (asset.IsTransferDepreciationRemoved == true)
                {
                    fixedAssetData.TransferDepreciation = $"₦{Utilities.FormatAmount(-asset.TransferDepreciation)}";
                    transferDepreciationValue += -asset.TransferDepreciation;
                }
                else
                {
                    fixedAssetData.TransferDepreciation = $"₦{Utilities.FormatAmount(asset.TransferDepreciation)}";
                    transferDepreciationValue += asset.TransferDepreciation;
                }

                if (asset.IsTransferCostRemoved == true)
                {
                    fixedAssetData.TransferCost = $"₦{Utilities.FormatAmount(-asset.TransferCost)}";
                    transferValue += -asset.TransferCost;
                }
                else
                {
                    fixedAssetData.TransferCost = $"₦{Utilities.FormatAmount(asset.TransferCost)}";
                    transferValue += asset.TransferCost;
                }
                fixedAssetDatas.Add(fixedAssetData);
                i++;
            }

            foreach (var netbook in fixedAssetResponse.netBookValue)
            {
                netBookValues.Add(new TaxComputationAPI.Dtos.NetBookValue
                {
                    value = $"{Utilities.FormatAmount(netbook.value)}"
                });


            }

            var total = new TaxComputationAPI.Dtos.Total();
            total.OpeningCostTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.OpeningCostTotal)}";
            total.AdditionCostTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.AdditionCostTotal)}";
            total.ClosingCostTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.ClosingCostTotal)}";
            total.DisposalCostTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.DisposalCostTotal)}";
            total.OpeningDepreciationTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.OpeningDepreciationTotal)}";
            total.AdditionDepreciationTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.AdditionDepreciationTotal)}";
            total.DisposalDepreciationTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.DisposalDepreciationTotal)}";
            total.ClosingDepreciationTotal = $"₦{Utilities.FormatAmount(fixedAssetResponse.total.ClosingDepreciationTotal)}";
            total.TransferCostTotal = $"₦{Utilities.FormatAmount(transferValue)}";
            total.TransferDepreciationTotal = $"₦{Utilities.FormatAmount(transferDepreciationValue)}";
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

        public Task DeleteFixedAssetById(int Id)
        {
            return _fixedAssetRepository.DeleteFixedAssetById(Id);
        }
    }
}


