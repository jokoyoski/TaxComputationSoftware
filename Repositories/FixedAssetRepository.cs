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
using FixedAssetData = TaxComputationAPI.ResponseModel.FixedAssetData;
using System.Data;
using TaxComputationAPI.Manager;
using Dapper;

namespace TaxComputationAPI.Repositories
{
    public class FixedAssetRepository : IFixedAssetRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly DatabaseManager _databaseManager;
        public FixedAssetRepository(DataContext dataContext, IMapper mapper, DatabaseManager databaseManager)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _databaseManager = databaseManager;
        }

        public async Task<FixedAssetResponse> GetFixedAssetsByCompany(int companyId, int yearId)
        {
            /* var result = (from s in _dataContext.FixedAsset
                           join b in _dataContext.FinancialYear on s.YearId equals b.Name
                           join c in _dataContext.AssetMapping on s.AssetId equals c.Id
                           join x in _dataContext.Company on s.CompanyId equals x.Id
                           where s.CompanyId == companyId && s.YearId == yearId
                           select new FixedAssetData
                           {
                               Id = s.Id,
                               CompanyName = x.CompanyName,
                               Year = b.Name,
                               FixedAssetName = c.AssetName,
                               OpeningCost = s.OpeningCost,
                               CostAddition = s.CostAddition,
                               CostDisposal = s.CostDisposal,
                               OpeningDepreciation = s.OpeningDepreciation,
                               DepreciationAddition = s.DepreciationAddition,
                               DepreciationDisposal = s.DepreciationAddition,
                               TransferCost = s.TransferCost,
                               TransferDepreciation = s.TransferDepreciation,
                               IsTransferCostRemoved = s.IsTransferCostRemoved,
                               IsTransferDepreciationRemoved = s.IsTransferDepreciationRemoved

                           }
             ).OrderBy(x => x.Id);*/
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);
                parameters.Add("@YearId", yearId);
                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<FixedAssetData>();
                FixedAssetResponse fixedAssetResponse = new FixedAssetResponse();
                fixedAssetResponse.FixedAssetData = result.ToList();
                fixedAssetResponse.netBookValue = new List<ResponseModel.NetBookValue>();
                fixedAssetResponse.total = new Total();
                return fixedAssetResponse;

            }

            

        }

        public async Task<int> SaveFixedAsset(CreateFixedAssetDto fixedAssetDto)
        {
           int valueId=0;
            var value = _mapper.Map<FixedAsset>(fixedAssetDto);
            var record = _dataContext.FixedAsset.FirstOrDefault(x => x.CompanyId == value.CompanyId && x.YearId == value.YearId && x.AssetId == fixedAssetDto.AssetId);
            if (record == null && fixedAssetDto.IsCost == true)
            {
                var fixedAsset = new FixedAsset
                {
                    CompanyId = fixedAssetDto.CompanyId,
                    YearId = fixedAssetDto.YearId,
                    AssetId = fixedAssetDto.AssetId,
                    OpeningCost = fixedAssetDto.OpeningCost,
                    CostAddition = fixedAssetDto.CostAddition,
                    CostDisposal = fixedAssetDto.CostDisposal,
                    TransferCost = fixedAssetDto.TransferCost,
                    IsTransferCostRemoved = fixedAssetDto.IsTransferCostRemoved

                };
                await _dataContext.AddAsync(fixedAsset);
                 _dataContext.SaveChanges();
                  valueId=fixedAsset.Id;

            }
            else if (record == null && fixedAssetDto.IsCost == false)
            {
                var fixedAsset = new FixedAsset
                {
                    CompanyId = fixedAssetDto.CompanyId,
                    YearId = fixedAssetDto.YearId,
                    AssetId = fixedAssetDto.AssetId,
                    OpeningDepreciation = fixedAssetDto.OpeningDepreciation,
                    DepreciationAddition = fixedAssetDto.DepreciationAddition,
                    DepreciationDisposal = fixedAssetDto.DepreciationDisposal,
                    TransferDepreciation = fixedAssetDto.TransferDepreciation,
                    IsTransferDepreciationRemoved = fixedAssetDto.IsTransferDepreciationRemoved


                };
                await _dataContext.AddAsync(fixedAsset);
                _dataContext.SaveChanges();
                 valueId=fixedAsset.Id;

            }
            else if (record != null && fixedAssetDto.IsCost == true)
            {

                record.CompanyId = fixedAssetDto.CompanyId;
                record.YearId = fixedAssetDto.YearId;
                record.AssetId = fixedAssetDto.AssetId;
                record.OpeningCost = fixedAssetDto.OpeningCost;
                record.CostAddition = fixedAssetDto.CostAddition;
                record.CostDisposal = fixedAssetDto.CostDisposal;
                record.TransferCost = fixedAssetDto.TransferCost;
                record.IsTransferCostRemoved = fixedAssetDto.IsTransferCostRemoved;
                 valueId=record.Id;
                 _dataContext.SaveChanges();

            }
            else if (record != null && fixedAssetDto.IsCost == false)
            {
                record.CompanyId = fixedAssetDto.CompanyId;
                record.YearId = fixedAssetDto.YearId;
                record.AssetId = fixedAssetDto.AssetId;
                record.OpeningDepreciation = fixedAssetDto.OpeningDepreciation;
                record.DepreciationAddition = fixedAssetDto.DepreciationAddition;
                record.DepreciationDisposal = fixedAssetDto.DepreciationDisposal;
                record.TransferDepreciation = fixedAssetDto.TransferDepreciation;
                record.IsTransferDepreciationRemoved = fixedAssetDto.IsTransferDepreciationRemoved;
                 valueId=record.Id;
                 _dataContext.SaveChanges();
            }
            
            return valueId;
        }
    }
}




