using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Helpers.Response;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Model;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Repositories
{
    public class UtilitiesRepository : IUtilitiesRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<UtilitiesRepository> _logger;

        public UtilitiesRepository(DatabaseManager databaseManager, IEmailService emailService, ILogger<UtilitiesRepository> logger)
        {
            _databaseManager = databaseManager;
            _emailService = emailService;
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

                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

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
                    parameters.Add("@CompanyId", financialYear.CompanyId);
                    parameters.Add("@OpeningDate", financialYear.OpeningDate);
                    parameters.Add("@ClosingDate", financialYear.ClosingDate);
                    parameters.Add("@FinancialDate", financialYear.FinancialDate);


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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
                throw new SystemException(e.Message);
            }
        }


        public async Task UpdateFinancialYearAsync(FinancialYear financialYear)
        {
            if (financialYear == null) throw new ArgumentNullException(nameof(financialYear));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", financialYear.Id);
                    parameters.Add("@Name", financialYear.Name);
                    parameters.Add("@CompanyId", financialYear.CompanyId);
                    parameters.Add("@OpeningDate", financialYear.OpeningDate);
                    parameters.Add("@ClosingDate", financialYear.ClosingDate);
                    parameters.Add("@FinancialDate", financialYear.FinancialDate);


                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Update_Financial_Year]", parameters, commandType: CommandType.StoredProcedure);
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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
                throw new SystemException(e.Message);
            }
        }


        public async Task DeleteFinancialYearAsync(FinancialYear financialYear)
        {
            if (financialYear == null) throw new ArgumentNullException(nameof(financialYear));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@CompanyId", financialYear.CompanyId);


                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Delete_Financial_Year]", parameters, commandType: CommandType.StoredProcedure);
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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
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

                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                    throw e;
                }

                return result;
            }
        }

        public async Task<List<FinancialYear>> GetFinancialCompanyAsync(int companyId)
        {
            if (companyId <= 0) throw new ArgumentNullException(nameof(companyId));

            var result = default(IEnumerable<FinancialYear>);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);

                try
                {
                    result = await conn.QueryAsync<FinancialYear>("[dbo].[usp_Get_Financial_Year_By_CompanyId]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {

                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                    throw e;
                }

                return result.ToList();
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

                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                    throw e;
                }

                return result.ToList();
            }
        }


         public async Task<List<PreNotification>> GetPreNotification()
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                try
                {
                    var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_All_PreNotification]", null, commandType: CommandType.StoredProcedure);
                    var result = await record.ReadAsync<PreNotification>();
                    conn.Close();
                    return result.ToList();
                }
                catch (Exception e)
                {

                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
                    throw e;
                }
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
                    
                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                    throw e;
                }

                return result;
            }
        }

          public async Task<AllowableDisAllowable> GetAllowableDisAllowableByTrialBalanceId(int Id)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@TrialBalanceId", Id);

                var record = conn.QueryFirstOrDefault<AllowableDisAllowable>("[dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId]", parameters, commandType: CommandType.StoredProcedure);
                return record;
            }


            return null;
        }

         public async Task DeleteFairGainByTrialBalanceId(int Id)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TrialBalanceId", Id);
                try
                {
                    conn.Execute("[dbo].[Delete_Fair_Gain_By_TrialBalanceId]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {

                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                    throw e;
                }
            }
        }




        public async Task<AllowableDisAllowable> GetAllowableDisAllowableById(int Id)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", Id);

                var record = conn.QueryFirstOrDefault<AllowableDisAllowable>("[dbo].[usp_Get_Allowable_DisAllowable_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                return record;
            }


            return null;
        }



        public async Task AddCompanyCode(CompanyCode companyCode)
        {
            if (companyCode == null) throw new ArgumentNullException(nameof(companyCode));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@NextExecution", companyCode.NextExecution);

                    parameters.Add("@CompanyId", companyCode.CompanyId);

                    parameters.Add("@Code", companyCode.Code);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Insert_Into_Company_Code_Table]", parameters, commandType: CommandType.StoredProcedure);
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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
                throw new SystemException(e.Message);
            }
        }



        public async Task<CompanyCode> GetCompanyCodeByCodeId(int companyId)
        {
            if (companyId == 0) throw new ArgumentNullException(nameof(companyId));

            var result = default(CompanyCode);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);

                try
                {
                    result = conn.QueryFirstOrDefault<CompanyCode>("[dbo].[usp_Get_CompanyCode_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {

                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

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
                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                throw new SystemException(e.Message);
            }
        }

        public async Task DeleteAssetMappingAsync(int id)
        {

            if (id < 0) throw new ArgumentNullException(nameof(id));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();


                    DynamicParameters parameters = new DynamicParameters();


                    parameters.Add("@Id", id);

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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                throw new SystemException(e.Message);
            }
        }

        public async Task<decimal> GetAmount(int moduleId, string additionalInfo)
        {
            decimal finalAmount = 0;

            // var result = default(IEnumerable<Amount>);


            if (additionalInfo == "cost")
            {



                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    var result = default(IEnumerable<DebitAmount>);
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@ModuleId", moduleId);
                    parameters.Add("@AdditionalInfo", additionalInfo);

                    try
                    {
                        result = await conn.QueryAsync<DebitAmount>("[dbo].[usp_Get_Amount_Debit]", parameters, commandType: CommandType.StoredProcedure);
                        //var record = await result.ReadAsync<Amount>();
                        //var results = record.ToList();
                        foreach (var item in result)
                        {
                            finalAmount += item.Debit;
                            // return finalAmount;
                        }

                        return finalAmount;
                        conn.Close();
                    }
                    catch (Exception e)
                    {

                        _logger.LogError(e.Message);
                        await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                        throw e;
                    }


                }



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
                        var result = await conn.QueryAsync<CreditAmount>("[dbo].[usp_Get_Amount_Credit]", parameters, commandType: CommandType.StoredProcedure);
                        //var record = await result.ReadAsync<Amount>();
                        //var results = record.ToList();
                        foreach (var item in result)
                        {
                            finalAmount += item.Credit;
                            //return finalAmount;
                        }

                        conn.Close();
                        return finalAmount;



                    }
                    catch (Exception e)
                    {

                        _logger.LogError(e.Message);
                        await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                        throw e;
                    }


                }



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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                throw new SystemException(e.Message);
            }

        }

        public async Task DeleteAllowableDisAllowableById(int Id)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                try
                {
                    conn.Execute("[dbo].[Delete_Allowable_DisAllowable_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {

                    _logger.LogError(e.Message);
                    await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                    throw e;
                }
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

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
                throw new SystemException(e.Message);
            }
        }
    }
}
