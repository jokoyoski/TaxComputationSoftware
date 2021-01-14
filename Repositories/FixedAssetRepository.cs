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

        private readonly IMapper _mapper;
        private readonly DatabaseManager _databaseManager;
        public FixedAssetRepository(IMapper mapper, DatabaseManager databaseManager)
        {

            _mapper = mapper;
            _databaseManager = databaseManager;
        }


        public async Task<FixedAsset> GetFixedAssetsByCompanyYearIdAssetId(int companyId, int yearId, int assetId)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);
                parameters.Add("@YearId", yearId);
                parameters.Add("@AssetId", assetId);
                var record = await conn.QueryFirstOrDefaultAsync<FixedAsset>("[dbo].[usp_Get_Fixed_Asset_By_CompanyId_And_YearId_AssetId]", parameters, commandType: CommandType.StoredProcedure);
                return record;

            }



        }


        public async Task<FixedAsset> GetFixedAssetsById(int id)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var record = await conn.QueryFirstOrDefaultAsync<FixedAsset>("[dbo].[usp_Get_Fixed_Asset_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                return record;

            }



        }







        public async Task<FixedAssetResponse> GetFixedAssetsByCompany(int companyId, int yearId)
        {

            try
            {
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
            catch (Exception ex)
            {

            }
            return null;

        }

        public async Task DeleteFixedAssetById(int Id)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                try
                {
                    conn.Execute("[dbo].[usp_Delete_Fixed_Asset_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }



        public async Task<int> SaveFixedAsset(CreateFixedAssetDto fixedAssetDto)
        {
            int valueId = 0;
            var value = _mapper.Map<FixedAsset>(fixedAssetDto);
            if (fixedAssetDto.IsCost)
            {
                using (IDbConnection con = await _databaseManager.DatabaseConnection())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CompanyId", fixedAssetDto.CompanyId);
                    parameters.Add("@YearId", fixedAssetDto.YearId);
                    parameters.Add("@AssetId", fixedAssetDto.AssetId);
                    parameters.Add("@OpeningCost", fixedAssetDto.OpeningCost);
                    parameters.Add("@TransferCost", fixedAssetDto.TransferCost);
                    parameters.Add("@CostAddition", fixedAssetDto.CostAddition);
                    parameters.Add("@CostDisposal", fixedAssetDto.CostDisposal);
                    parameters.Add("@IsTransferCostRemoved", fixedAssetDto.IsTransferCostRemoved);
                    parameters.Add("@OpeningDepreciation", fixedAssetDto.OpeningDepreciation);
                    parameters.Add("@TransferDepreciation", fixedAssetDto.TransferDepreciation);
                    parameters.Add("@DepreciationAddition", fixedAssetDto.DepreciationAddition);
                    parameters.Add("@DepreciationDisposal", fixedAssetDto.DepreciationDisposal);
                    parameters.Add("@type", "Cost");
                    parameters.Add("@IsTransferDepreciationRemoved", fixedAssetDto.IsTransferDepreciationRemoved);
                    int rowAffected = con.Execute("[dbo].[usp_Insert_Fixed_Asset]", parameters, commandType: CommandType.StoredProcedure);
                    return rowAffected;
                }
            }
            else
            {

                using (IDbConnection con = await _databaseManager.DatabaseConnection())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CompanyId", fixedAssetDto.CompanyId);
                    parameters.Add("@YearId", fixedAssetDto.YearId);
                    parameters.Add("@AssetId", fixedAssetDto.AssetId);
                    parameters.Add("@OpeningCost", fixedAssetDto.OpeningCost);
                    parameters.Add("@TransferCost", fixedAssetDto.TransferCost);
                    parameters.Add("@CostAddition", fixedAssetDto.CostAddition);
                    parameters.Add("@CostDisposal", fixedAssetDto.CostDisposal);
                    parameters.Add("@IsTransferCostRemoved", fixedAssetDto.IsTransferCostRemoved);
                    parameters.Add("@OpeningDepreciation", fixedAssetDto.OpeningDepreciation);
                    parameters.Add("@TransferDepreciation", fixedAssetDto.TransferDepreciation);
                    parameters.Add("@DepreciationAddition", fixedAssetDto.DepreciationAddition);
                    parameters.Add("@DepreciationDisposal", fixedAssetDto.DepreciationDisposal);
                    parameters.Add("@type", "Costfff");
                    parameters.Add("@IsTransferDepreciationRemoved", fixedAssetDto.IsTransferDepreciationRemoved);
                    int rowAffected = con.Execute("[dbo].[usp_Insert_Fixed_Asset]", parameters, commandType: CommandType.StoredProcedure);
                    return rowAffected;
                }
            }
        }
    }
}




