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
              fixedAssetData.OpeningCost=$"{Utilities.FormatAmount(asset.OpeningCost)}";
              fixedAssetData.CostAddition=$"{Utilities.FormatAmount(asset.CostAddition)}";
              fixedAssetData.CostDisposal=$"({Utilities.FormatAmount(asset.CostDisposal)})";
              fixedAssetData.CostClosing=$"{Utilities.FormatAmount(asset.CostClosing)}";
              fixedAssetData.OpeningDepreciation=$"{Utilities.FormatAmount(asset.OpeningDepreciation)}";
              fixedAssetData.DepreciationAddition=$"{Utilities.FormatAmount(asset.DepreciationAddition)}";
              fixedAssetData.DepreciationDisposal=$"{Utilities.FormatAmount(asset.DepreciationAddition)}";
              fixedAssetData.DepreciationClosing=$"{Utilities.FormatAmount(asset.DepreciationClosing)}";
               if(asset.IsTransferDepreciationRemoved==true){
                 fixedAssetData.TransferDepreciation=$"({Utilities.FormatAmount(asset.TransferDepreciation)})";
               }
               else{
                   fixedAssetData.TransferDepreciation=$"{Utilities.FormatAmount(asset.TransferDepreciation)}";
               }

                if(asset.IsTransferCostRemoved==true){
                 fixedAssetData.TransferCost=$"({Utilities.FormatAmount(asset.TransferCost)})";
               }
               else{
                   fixedAssetData.TransferCost=$"{Utilities.FormatAmount(asset.TransferCost)}";
               }
             
              
             fixedAssetDatas.Add(fixedAssetData);
          }

          foreach(var netbook in fixedAssetResponse.netBookValue){
                netBookValues.Add(new TaxComputationAPI.Dtos.NetBookValue{
               value=$"{Utilities.FormatAmount(netbook.value)}"
              });
            

          }

          
          var total= new TaxComputationAPI.Dtos.Total{
                 OpeningCostTotal=$"{Utilities.FormatAmount(fixedAssetResponse.total.OpeningCostTotal)}",
                 AdditionCostTotal=$"{Utilities.FormatAmount(fixedAssetResponse.total.AdditionCostTotal)}",
                 ClosingCostTotal=$"{Utilities.FormatAmount(fixedAssetResponse.total.ClosingCostTotal)}",
                 DisposalCostTotal=$"{Utilities.FormatAmount(fixedAssetResponse.total.DisposalCostTotal)}",
                 OpeningDepreciationTotal=$"{Utilities.FormatAmount(fixedAssetResponse.total.OpeningDepreciationTotal)}",
                 AdditionDepreciationTotal=$"{Utilities.FormatAmount(fixedAssetResponse.total.AdditionDepreciationTotal)}",
                 DisposalDepreciationTotal=$"{Utilities.FormatAmount(fixedAssetResponse.total.DisposalDepreciationTotal)}",
                 ClosingDepreciationTotal=$"{Utilities.FormatAmount(fixedAssetResponse.total.ClosingDepreciationTotal)}",
          };
          TaxComputationAPI.Dtos.FixedAssetResponseDto fixedAsset=new   TaxComputationAPI.Dtos.FixedAssetResponseDto();
          fixedAsset.FixedAssetData=fixedAssetDatas;
          fixedAsset.netBookValue=netBookValues;
          fixedAsset.total=total;

          return fixedAsset;
        }
    }
}


