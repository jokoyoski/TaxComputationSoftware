using AutoMapper;
using TaxComputationAPI.Data;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaxComputationAPI.ResponseModel;
using System;
using Total = TaxComputationAPI.ResponseModel.Total;

namespace TaxComputationAPI.Repositories
{
    public class FixedAssetRepository : IFixedAssetRepository
    {
         private readonly DataContext _dataContext;
         private readonly IMapper    _mapper;
        public FixedAssetRepository(DataContext dataContext,IMapper mapper ){
             _dataContext=dataContext;
             _mapper=mapper;
        }

        public async Task<FixedAssetResponse> GetFixedAssetsByCompany(int companyId, int yearId)
        {
            var result=(from s in _dataContext.FixedAsset 
                join b in _dataContext.FinancialYear on s.YearId equals b.Id
                join  c in _dataContext.AssetClass on   s.AssetId equals c.Id
                join x in _dataContext.Company on s.CompanyId equals x.Id
                where s.CompanyId==companyId && s.YearId==yearId
                select new FixedAssetData{
                Id=s.Id,
              CompanyName=x.CompanyName,
              Year=b.Name,
              FixedAssetName=c.Name,
              OpeningCost=s.OpeningCost,
              CostAddition=s.CostAddition,
              CostDisposal=s.CostDisposal,
              CostClosing=s.CostClosing,
              OpeningDepreciation=s.OpeningDepreciation,
              DepreciationAddition=s.DepreciationAddition,
              DepreciationDisposal=s.DepreciationAddition,
              DepreciationClosing=s.DepreciationClosing,

            }
            ).OrderBy(x=>x.Id).ToList();
            FixedAssetResponse fixedAssetResponse= new FixedAssetResponse();
            fixedAssetResponse.FixedAssetData=result;
            fixedAssetResponse.netBookValue=new List<ResponseModel.NetBookValue>();
            fixedAssetResponse.total=new Total();
            return fixedAssetResponse;
             
        }

        public  async Task SaveFixedAsset(CreateFixedAssetDto fixedAssetDto)
        {
          
           var value=_mapper.Map<FixedAsset>(fixedAssetDto);
           var record=_dataContext.FixedAsset.FirstOrDefault(x=>x.CompanyId==value.CompanyId&&x.YearId==value.YearId);
           if(record==null && fixedAssetDto.IsCost==true){
             var fixedAsset=new FixedAsset{
             CompanyId=fixedAssetDto.CompanyId,
             YearId=fixedAssetDto.YearId,
             AssetId=fixedAssetDto.AssetId,
             OpeningCost=fixedAssetDto.OpeningCost,
             CostAddition=fixedAssetDto.CostAddition,
             CostDisposal=fixedAssetDto.CostDisposal,
             CostClosing=fixedAssetDto.CostClosing,
            
            };
             await _dataContext.AddAsync(fixedAsset);

           } else if (record==null && fixedAssetDto.IsCost==false){
               var fixedAsset=new FixedAsset{
             CompanyId=fixedAssetDto.CompanyId,
             YearId=fixedAssetDto.YearId,
             AssetId=fixedAssetDto.AssetId,
             OpeningDepreciation=fixedAssetDto.OpeningDepreciation,
             DepreciationAddition=fixedAssetDto.DepreciationAddition,
             DepreciationDisposal=fixedAssetDto.DepreciationDisposal,
             DepreciationClosing=fixedAssetDto.DepreciationClosing,

            };
             _dataContext.AddAsync(fixedAsset);
           
           }else if(record!=null && fixedAssetDto.IsCost==true){
           
             record.CompanyId=fixedAssetDto.CompanyId;
             record.YearId=fixedAssetDto.YearId;
             record.AssetId=fixedAssetDto.AssetId;
             record.OpeningCost=fixedAssetDto.OpeningCost;
             record.CostAddition=fixedAssetDto.CostAddition;
             record.CostDisposal=fixedAssetDto.CostDisposal;
             record.CostClosing=fixedAssetDto.CostClosing;
            
            }
            else if(record!=null && fixedAssetDto.IsCost==false){
             record.CompanyId=fixedAssetDto.CompanyId;
             record.YearId=fixedAssetDto.YearId;
             record.AssetId=fixedAssetDto.AssetId;
             record.OpeningDepreciation=fixedAssetDto.OpeningDepreciation;
             record.DepreciationAddition=fixedAssetDto.DepreciationAddition;
             record.DepreciationDisposal=fixedAssetDto.DepreciationDisposal;
             record.DepreciationClosing=fixedAssetDto.DepreciationClosing;
            }
            _dataContext.SaveChanges();
           }
        }
    }

    /*   public  string CompanyName  {get;set;}

         public string Year {get;set;}
        public string FixedAssetName {get;set;}
        public long OpeningCost {get;set;}
        
        public long CostAddition {get;set;}

        public long CostDisposal {get;set;}

        public long CostClosing {get;set;}

         public long OpeningDepreciation {get;set;}
        
        public long DepreciationAddition {get;set;}

        public long DepreciationDisposal {get;set;}

        public long DepreciationClosing {get;set;}*/


