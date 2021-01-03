using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using TaxComputationAPI.Manager;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Repositories
{
    public class DeferredTaxRepository : IDeferredTaxRepository
    {

        private readonly DatabaseManager _databaseManager;

        public DeferredTaxRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;

        }

        public async Task<int> CreateFairValueGain(FairValueGain fairValueGain)
        {

            try
            {
                int rowAffected = 0;
                using (IDbConnection con = await _databaseManager.DatabaseConnection())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CompanyId", fairValueGain.CompanyId);
                    parameters.Add("@YearId", fairValueGain.YearId);
                    parameters.Add("@TrialBalanceId", fairValueGain.TrialBalanceId);
                    parameters.Add("@SelectionId", fairValueGain.SelectionId);

                    rowAffected = con.Execute("[dbo].[Insert_Into_Deferred_Tax]", parameters, commandType: CommandType.StoredProcedure);
                }

                return rowAffected;
            }
            catch (Exception ex)
            {

            }

            return 4;
        }

        public async Task<int> CreateDeferredTaxBroughtFoward(int companyId, decimal deferredTaxBroughtFoward)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", companyId);
                parameters.Add("@IsStarted", true);
                parameters.Add("@DeferredTaxBroughtFoward", deferredTaxBroughtFoward);
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

            }
            return null;
        }

       

        public async Task<DeferredTaxFoward> GetDeferredTaxFowarByCompanyId(int companyId)
        {

            try
            {
                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@CompanyId", companyId);



                    var record =  conn.QueryFirstOrDefault<DeferredTaxFoward>("[dbo].[usp_Get_Deferred_Tax_Brought_Foward_By_CompanyId]", parameters, commandType: CommandType.StoredProcedure);
                    return record;
                }


                return null;
            }
            catch (Exception ex)
            {

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

                    throw e;
                }
            }
        }



    }
}