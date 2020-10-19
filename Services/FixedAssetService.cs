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

namespace TaxComputationAPI.Services
{
    public class FixedAssetService : IFixedAssetService
    {
        private readonly IFixedAssetRepository _fixedAssetRepository;
        private readonly ITrialBalanceRepository _trialBalanceRepository;
        private readonly  IUtilitiesRepository _utilitiesRepository;
        public FixedAssetService(IFixedAssetRepository fixedAssetRepository,IUtilitiesRepository utilitiesRepository,ITrialBalanceRepository trialBalanceRepository){
             _fixedAssetRepository=fixedAssetRepository;
             _trialBalanceRepository=trialBalanceRepository;
             _utilitiesRepository=utilitiesRepository;
        }

        public async Task<FixedAssetResponse> GetFixedAssetsByCompany(int companyId, int yearId)
        {
            long openingCostTotal=0;
            long adddtionCostTotal=0;
            long disposalCostTotal =0;
            long closingCostTotal=0;
            long openingDepreciationTotal=0;
            long adddtionDepreciationTotal=0;
            long disposalDepreciationTotal=0;
            long closingDepreciationTotal=0;


            List<Total> totals=new List<Total>();
            List<NetBookValue> netBookValues =new List<NetBookValue>();


            var result= await _fixedAssetRepository.GetFixedAssetsByCompany(companyId,yearId);
            if(result.FixedAssetData.Count<=0){
                return null;
            }
            var cost=result.FixedAssetData.Where(x=>x.Id!=0);
             foreach(var x  in cost){
              openingCostTotal += x.OpeningCost;
              adddtionCostTotal += x.CostAddition;
              disposalCostTotal += x.CostDisposal;
              closingCostTotal  += x.CostClosing;
              openingDepreciationTotal += x.OpeningDepreciation;
              adddtionDepreciationTotal += x.DepreciationAddition;
              disposalDepreciationTotal += x.DepreciationDisposal;
              closingDepreciationTotal  += x.DepreciationClosing;
              netBookValues.Add(new NetBookValue{
               value=closingCostTotal-closingDepreciationTotal
              });


             }
             result.total=new Total{
                 OpeningCostTotal=openingCostTotal,
                 AdditionCostTotal=adddtionCostTotal,
                 ClosingCostTotal=closingCostTotal,
                 DisposalCostTotal=disposalCostTotal,
                 OpeningDepreciationTotal=openingDepreciationTotal,
                 AdditionDepreciationTotal=adddtionDepreciationTotal,
                 DisposalDepreciationTotal=disposalDepreciationTotal,
                 ClosingDepreciationTotal=closingDepreciationTotal,
                 
                
             };
             result.netBookValue=netBookValues;
             
            return result;
        }

        public  async Task SaveFixedAsset(CreateFixedAssetDto fixedAsset)
        {
            GetMappedDetails getMappedDetails =new GetMappedDetails();
            string trialBalanceValue=getMappedDetails.MappedTo(fixedAsset.MappedCode);
            var yearRecord=await _utilitiesRepository.GetFinancialYearAsync(fixedAsset.YearId);
            if(yearRecord==null){
                var createYear = new FinancialYear{
                    Name=fixedAsset.YearId
                };
               await  _utilitiesRepository.AddFinancialYearAsync(createYear);
            }
            foreach(var value in fixedAsset.TriBalanceId){
             await _trialBalanceRepository.UpdateTrialBalance(fixedAsset.AssetId,trialBalanceValue);
            }
            
             await _fixedAssetRepository.SaveFixedAsset(fixedAsset);
              
            
        }
    }
}


