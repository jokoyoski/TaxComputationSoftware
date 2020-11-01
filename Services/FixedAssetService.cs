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
        public FixedAssetService(IFixedAssetRepository fixedAssetRepository, IUtilitiesRepository utilitiesRepository, ITrialBalanceRepository trialBalanceRepository)
        {
            _fixedAssetRepository = fixedAssetRepository;
            _trialBalanceRepository = trialBalanceRepository;
            _utilitiesRepository = utilitiesRepository;
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
                closingCostTotal += _utilitiesRepository.GetAmount(x.Id, "cost");
                openingDepreciationTotal += x.OpeningDepreciation;
                adddtionDepreciationTotal += x.DepreciationAddition;
                disposalDepreciationTotal += x.DepreciationDisposal;
                closingDepreciationTotal += _utilitiesRepository.GetAmount(x.Id, "depreciation");
                transferCostTotal += x.TransferCost;
                transferDepreciationTotal = x.TransferDepreciation;

                netBookValues.Add(new NetBookValue
                {
                    value = _utilitiesRepository.GetAmount(x.Id, "cost") - _utilitiesRepository.GetAmount(x.Id, "depreciation")
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

            return FormatAmount(result);
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
                foreach (var value in fixedAsset.TriBalanceId)
                {
                    if (fixedAsset.IsCost == true)
                    {

                        _utilitiesRepository.AddTrialBalanceMapping(value, result, "fixedasset", "cost");
                    }
                    else
                    {

                        _utilitiesRepository.AddTrialBalanceMapping(value, result, "fixedasset", "depreciation");

                    }


                }

                /* if (firstItemInArray.IsCheck == true)
                 {
                     foreach (var value in fixedAsset.TriBalanceId)
                     {
                         await _trialBalanceRepository.UpdateTrialBalance(value, null, true); 
                         _utilitiesRepository.DeleteTrialBalancingMapping(value);
                     }


                 }else{

                 }*/

            }
            else
            {
                var result = await _fixedAssetRepository.SaveFixedAsset(fixedAsset);

            }




        }


        public TaxComputationAPI.Dtos.FixedAssetResponseDto FormatAmount(FixedAssetResponse fixedAssetResponse)
        {
            List<FixedAssetData> fixedAssetDatas = new List<FixedAssetData>();
            List<TaxComputationAPI.Dtos.NetBookValue> netBookValues = new List<TaxComputationAPI.Dtos.NetBookValue>();
            List<TaxComputationAPI.Dtos.Total> totals = new List<TaxComputationAPI.Dtos.Total>();
            foreach (var asset in fixedAssetResponse.FixedAssetData)
            {
                var fixedAssetData = new FixedAssetData();
                fixedAssetData.Id = asset.Id;
                fixedAssetData.CompanyName = asset.CompanyName;
                fixedAssetData.Year = asset.Year;
                fixedAssetData.FixedAssetName = asset.FixedAssetName;
                fixedAssetData.OpeningCost = $"{Utilities.FormatAmount(asset.OpeningCost)}";
                fixedAssetData.CostAddition = $"{Utilities.FormatAmount(asset.CostAddition)}";
                fixedAssetData.CostDisposal = $"({Utilities.FormatAmount(asset.CostDisposal)})";
                fixedAssetData.CostClosing = $"{Utilities.FormatAmount(_utilitiesRepository.GetAmount(asset.Id, "cost"))}";
                fixedAssetData.OpeningDepreciation = $"{Utilities.FormatAmount(asset.OpeningDepreciation)}";
                fixedAssetData.DepreciationAddition = $"{Utilities.FormatAmount(asset.DepreciationAddition)}";
                fixedAssetData.DepreciationDisposal = $"({Utilities.FormatAmount(asset.DepreciationDisposal)})";
                fixedAssetData.DepreciationClosing = $"{Utilities.FormatAmount(_utilitiesRepository.GetAmount(asset.Id, "depreciation"))}";
                if (asset.IsTransferDepreciationRemoved == true)
                {
                    fixedAssetData.TransferDepreciation = $"({Utilities.FormatAmount(asset.TransferDepreciation)})";
                }
                else
                {
                    fixedAssetData.TransferDepreciation = $"{Utilities.FormatAmount(asset.TransferDepreciation)}";
                }

                if (asset.IsTransferCostRemoved == true)
                {
                    fixedAssetData.TransferCost = $"({Utilities.FormatAmount(asset.TransferCost)})";
                }
                else
                {
                    fixedAssetData.TransferCost = $"{Utilities.FormatAmount(asset.TransferCost)}";
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


            var total = new TaxComputationAPI.Dtos.Total
            {
                OpeningCostTotal = $"{Utilities.FormatAmount(fixedAssetResponse.total.OpeningCostTotal)}",
                AdditionCostTotal = $"{Utilities.FormatAmount(fixedAssetResponse.total.AdditionCostTotal)}",
                ClosingCostTotal = $"{Utilities.FormatAmount(fixedAssetResponse.total.ClosingCostTotal)}",
                DisposalCostTotal = $"{Utilities.FormatAmount(fixedAssetResponse.total.DisposalCostTotal)}",
                OpeningDepreciationTotal = $"{Utilities.FormatAmount(fixedAssetResponse.total.OpeningDepreciationTotal)}",
                AdditionDepreciationTotal = $"{Utilities.FormatAmount(fixedAssetResponse.total.AdditionDepreciationTotal)}",
                DisposalDepreciationTotal = $"{Utilities.FormatAmount(fixedAssetResponse.total.DisposalDepreciationTotal)}",
                ClosingDepreciationTotal = $"{Utilities.FormatAmount(fixedAssetResponse.total.ClosingDepreciationTotal)}",
            };
            TaxComputationAPI.Dtos.FixedAssetResponseDto fixedAsset = new TaxComputationAPI.Dtos.FixedAssetResponseDto();
            fixedAsset.FixedAssetData = fixedAssetDatas;
            fixedAsset.netBookValue = netBookValues;
            fixedAsset.total = total;

            return fixedAsset;
        }

        public async Task DeleteFixedAsset(int fixedAssetId)
        {
            await _trialBalanceRepository.UpdateTrialBalance(fixedAssetId, null, true);
            _utilitiesRepository.DeleteTrialBalancingMapping(fixedAssetId);
        }
    }
}


