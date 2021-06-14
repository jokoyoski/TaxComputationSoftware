using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Manager;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Repositories
{
    public class DeferredTaxRepository : IDeferredTaxRepository
    {

        private readonly DatabaseManager _databaseManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<DeferredTaxRepository> _logger;

        public DeferredTaxRepository(DatabaseManager databaseManager, IEmailService emailService, ILogger<DeferredTaxRepository> logger)
        {
            _databaseManager = databaseManager;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> CreateDeferredTaxBroughtFoward(int companyId, decimal deferredTaxBroughtFoward, int yearId)
        {

            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", companyId);
                parameters.Add("@YearId", yearId);
                parameters.Add("@DeferredTaxCarriedFoward", deferredTaxBroughtFoward);
                rowAffected = con.Execute("[dbo].[usp_Insert_Into_DeferredTax_Brought_Foward]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public async Task<IEnumerable<FairValueGain>> GetFairValueGainByCompanyIdAndYear(int companyId, int year)
        {

            try
            {
                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@CompanyId", companyId);
                    parameters.Add("@YearId", year);


                    var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_Deferred_Fair_Value_Gain_By_CompanyId_Year]", parameters, commandType: CommandType.StoredProcedure);
                    var result = await record.ReadAsync<FairValueGain>();
                    return result;
                }



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }
            return null;
        }



        public async Task<IEnumerable<DeferredTaxFoward>> GetDeferredTaxFowarByCompanyId(int companyId)
        {

            try
            {
                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CompanyId", companyId);

                    var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId]", parameters, commandType: CommandType.StoredProcedure);
                    var result = await record.ReadAsync<DeferredTaxFoward>();
                    return result;

                }


                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }
            return null;
        }







        public async Task<int> UpdateDeferredTaxBroughtFowardByDeferredTax(int companyId, decimal broughtFoward)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", companyId);
                parameters.Add("@DeferredTaxCarriedFoward", broughtFoward);
                rowAffected = con.Execute("[dbo].[usp_Update_BroughtFoward_By_Deferred_Tax]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }








        public async Task<int> UpdateDeferredTaxfById(int companyId)  //background job
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", companyId);
                rowAffected = con.Execute("[dbo].[usp_Update_Deferred_Tax_Bf_Background]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
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


        public async Task DeleteDeferredTaxBroughtFoward(int yearId)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", yearId);
                try
                {
                    conn.Execute("[dbo].[usp_Delete_Deferred_Tax_Brought_Foward]", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task DeleteIncomeTaxBroughtFoward(int yearId)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", yearId);
                try
                {
                    conn.Execute("[dbo].[usp_Delete_IncomeTax_Brought_Foward]", parameters, commandType: CommandType.StoredProcedure);
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
    }
}