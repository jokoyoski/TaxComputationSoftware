using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Helpers.Response;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class UtilitiesRepository : IUtilitiesRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly ILogger<UtilitiesRepository> _logger;

        public UtilitiesRepository(DatabaseManager databaseManager, ILogger<UtilitiesRepository> logger)
        {
            _databaseManager = databaseManager;
            _logger = logger;
        }

        public async Task<List<FinancialYear>> GetFinancialYearAsync()
        {
            var result = default(IEnumerable<FinancialYear>);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                try
                {
                    result = await conn.QueryAsync<FinancialYear>("[dbo].[usp_Get_Financial_Year]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result.ToList();
            }
        }

        public async Task AddFinancialYearAsync(FinancialYear financialYear)
        {
            if (financialYear == null) throw new ArgumentNullException(nameof(financialYear));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Name", financialYear.Name);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Insert_Financial_Year]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {

                        _logger.LogError($"{e.Message}");

                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }

        public async Task<FinancialYear> GetFinancialYearAsync(int year)
        {
            if (year <= 0) throw new ArgumentNullException(nameof(year));

            var result = default(FinancialYear);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", year);

                try
                {
                    result = conn.QueryFirstOrDefault<FinancialYear>("[dbo].[usp_Get_Financial_Year_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result;
            }
        }

        public async Task<List<AssetMapping>> GetAssetMappingAsync()
        {
            var result = default(IEnumerable<AssetMapping>);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                try
                {
                    result = await conn.QueryAsync<AssetMapping>("[dbo].[usp_Get_Asset_Mapping]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result.ToList();
            }
        }

        public async Task<AssetMapping> GetAssetMappingAsync(string Name)
        {
            if (string.IsNullOrEmpty(Name)) throw new ArgumentNullException(nameof(Name));

            var result = default(AssetMapping);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@AssetName", Name);

                try
                {
                    result = conn.QueryFirstOrDefault<AssetMapping>("[dbo].[usp_Get_AssetMapping_By_AssetName]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result;
            }
        }

        public async Task<AssetMapping> GetAssetMappingById(int Id)
        {
            if (Id <= 0) throw new ArgumentNullException(nameof(Id));

            var result = default(AssetMapping);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", Id);

                try
                {
                    result = conn.QueryFirstOrDefault<AssetMapping>("[dbo].[usp_Get_Asset_Mapping_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result;
            }
        }

        public async Task AddAssetMappingAsync(AssetMapping assetMapping)
        {
            if (assetMapping == null) throw new ArgumentNullException(nameof(assetMapping));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@AssetName", assetMapping.AssetName);

                    parameters.Add("@Initial", assetMapping.Initial);

                    parameters.Add("@Annual", assetMapping.Annual);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Insert_Asset_Mapping]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {

                        _logger.LogError($"{e.Message}");

                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }

        public async Task UpdateAssetMappingAsync(AssetMapping assetMapping)
        {
            if (assetMapping == null) throw new ArgumentNullException(nameof(assetMapping));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();


                    DynamicParameters parameters = new DynamicParameters();


                    parameters.Add("@Id", assetMapping.Id);

                    parameters.Add("@AssetName", assetMapping.AssetName);

                    parameters.Add("@Initial", assetMapping.Initial);

                    parameters.Add("@Annual", assetMapping.Annual);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Update_Asset_Mapping]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {

                        _logger.LogError($"{e.Message}");

                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }
        
        public async Task DeleteAssetMappingAsync(AssetMapping assetMapping)
        {

            if (assetMapping == null) throw new ArgumentNullException(nameof(assetMapping));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();


                    DynamicParameters parameters = new DynamicParameters();


                    parameters.Add("@Id", assetMapping.Id);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Delete_Asset_Mapping]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {

                        _logger.LogError($"{e.Message}");

                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }

        public async Task<decimal> GetAmount(int moduleId, string additionalInfo)
        {
            decimal finalAmount = 0;

            var result = default(IEnumerable<Amount>);


            if (additionalInfo == "cost")
            {
                


                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@ModuleId", moduleId);
                    parameters.Add("@AdditionalInfo", additionalInfo);

                    try
                    {
                        result = await conn.QueryAsync<Amount>("[dbo].[usp_Get_Amount_Debit]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"{e.Message}");

                        throw e;
                    }

                    result = result.ToList();
                }

                foreach (var item in result)
                {
                    finalAmount += item.amount;
                }

                return finalAmount;

            }
            else
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@ModuleId", moduleId);
                    parameters.Add("@AdditionalInfo", additionalInfo);

                    try
                    {
                        result = await conn.QueryAsync<Amount>("[dbo].[usp_Get_Amount_Credit]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"{e.Message}");

                        throw e;
                    }

                    result = result.ToList();
                }

                foreach (var item in result)
                {
                    finalAmount += item.amount;
                }

                return finalAmount;
            }


        }

        public async Task AddTrialBalanceMapping(int trialBalanceId, int moduleId, string moduleCode, string additionalInfo)
        {
            if (trialBalanceId <= 0) throw new ArgumentNullException(nameof(trialBalanceId));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@TrialBalanceId", trialBalanceId);

                    parameters.Add("@ModuleId", moduleId);

                    parameters.Add("@ModuleCode", moduleCode);

                    parameters.Add("@AdditionalInfo", additionalInfo);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Insert_Trial_Balance_Mapping]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {

                        _logger.LogError($"{e.Message}");

                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }

        }

        public async Task DeleteTrialBalancingMapping(int trialBalanceId)
        {
            if (trialBalanceId <= 0) throw new ArgumentNullException(nameof(trialBalanceId));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();


                    DynamicParameters parameters = new DynamicParameters();


                    parameters.Add("@Id", trialBalanceId);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Delete_Trial_Balance_Mapping]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {

                        _logger.LogError($"{e.Message}");

                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }
    }
}
