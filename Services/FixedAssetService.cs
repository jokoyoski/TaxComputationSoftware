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
        private readonly  IUtilitiesRepository _utilitiesRepository;
        public FixedAssetService(IFixedAssetRepository fixedAssetRepository,IUtilitiesRepository utilitiesRepository,ITrialBalanceRepository trialBalanceRepository){
             _fixedAssetRepository=fixedAssetRepository;
             _trialBalanceRepository=trialBalanceRepository;
             _utilitiesRepository=utilitiesRepository;
        }

        public async Task<TaxComputationAPI.Dtos.FixedAssetResponseDto> GetFixedAssetsByCompany(int companyId, int yearId)
        {
            long openingCostTotal=0;
            long adddtionCostTotal=0;
            long disposalCostTotal =0;
            long closingCostTotal=0;
            long openingDepreciationTotal=0;
            long adddtionDepreciationTotal=0;
            long disposalDepreciationTotal=0;
            long closingDepreciationTotal=0;
            long transferCostTotal=0;
            long transferDepreciationTotal=0;


            List<Total> totals=new List<Total>();
            List<NetBookValue> netBookValues =new List<NetBookValue>();


            var result= await _fixedAssetRepository.GetFixedAssetsByCompany(companyId,yearId);
            if(result.FixedAssetData.Count<=0){
                return null;
            }
            
             foreach(var x  in result.FixedAssetData){
              openingCostTotal += x.OpeningCost;
              adddtionCostTotal += x.CostAddition;
              disposalCostTotal += x.CostDisposal;
              closingCostTotal  += x.CostClosing;
              openingDepreciationTotal += x.OpeningDepreciation;
              adddtionDepreciationTotal += x.DepreciationAddition;
              disposalDepreciationTotal += x.DepreciationDisposal;
              closingDepreciationTotal  += x.DepreciationClosing;
              transferCostTotal+=x.TransferCost;
              transferDepreciationTotal=x.TransferDepreciation;

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
             
            return FormatAmount(result);
        }

        public  async Task SaveFixedAsset(CreateFixedAssetDto fixedAsset)
        {
            GetMappedDetails getMappedDetails =new GetMappedDetails();
           
            var yearRecord=await _utilitiesRepository.GetFinancialYearAsync(fixedAsset.YearId);
            if(yearRecord==null){
                var createYear = new FinancialYear{
                    Name=fixedAsset.YearId
                };
               await  _utilitiesRepository.AddFinancialYearAsync(createYear);
            }
            foreach(var value in fixedAsset.TriBalanceId){
            string trialBalanceValue=getMappedDetails.MappedTo("fixedasset");
             await _trialBalanceRepository.UpdateTrialBalance(value,trialBalanceValue);
            }
            
             await _fixedAssetRepository.SaveFixedAsset(fixedAsset);
              
            
        }

        public TaxComputationAPI.Dtos.FixedAssetResponseDto FormatAmount(FixedAssetResponse fixedAssetResponse){
           List<FixedAssetData> fixedAssetDatas=new List<FixedAssetData>();
           List<TaxComputationAPI.Dtos.NetBookValue> netBookValues =new List<TaxComputationAPI.Dtos.NetBookValue>();
           List<TaxComputationAPI.Dtos.Total> totals= new List<TaxComputationAPI.Dtos.Total>();
          foreach(var asset in fixedAssetResponse.FixedAssetData){
             var fixedAssetData=new FixedAssetData();
                fixedAssetData.Id=asset.Id;
              fixedAssetData.CompanyName=asset.CompanyName;
              fixedAssetData.Year=asset.Year;
              fixedAssetData.FixedAssetName=asset.FixedAssetName;
              fixedAssetData.OpeningCost=$"₦{asset.OpeningCost.ToString("0,00")}";
              fixedAssetData.CostAddition=$"₦{asset.CostAddition.ToString("0,00")}";
              fixedAssetData.CostDisposal=$"₦({asset.CostDisposal.ToString("0,00")})";
              fixedAssetData.CostClosing=$"₦{asset.CostClosing.ToString("0,00")}";
              fixedAssetData.OpeningDepreciation=$"₦{asset.OpeningDepreciation.ToString("0,00")}";
              fixedAssetData.DepreciationAddition=$"₦{asset.DepreciationAddition.ToString("0,00")}";
              fixedAssetData.DepreciationDisposal=$"₦{asset.DepreciationAddition.ToString("0,00")}";
              fixedAssetData.DepreciationClosing=$"₦{asset.DepreciationClosing.ToString("0,00")}";
               if(asset.IsTransferDepreciationRemoved==true){
                 fixedAssetData.TransferDepreciation=$"₦({asset.TransferDepreciation.ToString("0,00")})";
               }
               else{
                   fixedAssetData.TransferDepreciation=$"₦{asset.TransferDepreciation.ToString("0,00")}";
               }

                if(asset.IsTransferCostRemoved==true){
                 fixedAssetData.TransferCost=$"₦({asset.TransferCost.ToString("0,00")})";
               }
               else{
                   fixedAssetData.TransferCost=$"₦{asset.TransferCost.ToString("0,00")}";
               }
             
              
             fixedAssetDatas.Add(fixedAssetData);
          }

          foreach(var netbook in fixedAssetResponse.netBookValue){
                netBookValues.Add(new TaxComputationAPI.Dtos.NetBookValue{
               value=$"₦{netbook.value.ToString("0,00")}"
              });
            

          }

          
          var total= new TaxComputationAPI.Dtos.Total{
                OpeningCostTotal=$"₦{fixedAssetResponse.total.OpeningCostTotal.ToString("0,00")}",
                 AdditionCostTotal=$"₦{fixedAssetResponse.total.AdditionCostTotal.ToString("0,00")}",
                 ClosingCostTotal=$"₦{fixedAssetResponse.total.ClosingCostTotal.ToString("0,00")}",
                 DisposalCostTotal=$"₦{fixedAssetResponse.total.DisposalCostTotal.ToString("0,00")}",
                 OpeningDepreciationTotal=$"₦{fixedAssetResponse.total.OpeningDepreciationTotal.ToString("0,00")}",
                 AdditionDepreciationTotal=$"₦{fixedAssetResponse.total.AdditionDepreciationTotal.ToString("0,00")}",
                 DisposalDepreciationTotal=$"₦{fixedAssetResponse.total.DisposalDepreciationTotal.ToString("0,00")}",
                 ClosingDepreciationTotal=$"₦{fixedAssetResponse.total.ClosingDepreciationTotal.ToString("0,00")}",
          };
          TaxComputationAPI.Dtos.FixedAssetResponseDto fixedAsset=new   TaxComputationAPI.Dtos.FixedAssetResponseDto();
          fixedAsset.FixedAssetData=fixedAssetDatas;
          fixedAsset.netBookValue=netBookValues;
          fixedAsset.total=total;

          return fixedAsset;
        }
    }
}


