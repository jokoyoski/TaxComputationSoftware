using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Repositories
{
    public class IncomeTaxRepository : IIncomeTaxRepository
    {

        private readonly DatabaseManager _databaseManager;

        public IncomeTaxRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;

        }



        public async Task<IEnumerable<AllowableDisAllowable>> GetAllowableDisAllowableByCompanyIdYearId(int companyId, int year)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);
                parameters.Add("@YearId", year);

                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<AllowableDisAllowable>();
                return result;
            }


            return null;
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

                    throw e;
                }
            }
        }



        public async Task<IEnumerable<AllowableDisAllowable>> GetAllowableDisAllowableByCompanyIdYearIdAllowable(int companyId, int year, int allowable)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);
                parameters.Add("@YearId", year);
                parameters.Add("@IsAllowable", allowable);


                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_Allowable_DisAllowable_By_CompanyId_YearId_Allowable]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<AllowableDisAllowable>();
                return result;
            }


            return null;
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


        public async Task<AllowableDisAllowable> GetAllowableDisAllowableByTrialBalanceId(int Id)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", Id);

                var record = conn.QueryFirstOrDefault<AllowableDisAllowable>("[dbo].[usp_Get_Allowable_DisAllowable_By_TrialBalanceId]", parameters, commandType: CommandType.StoredProcedure);
                return record;
            }


            return null;
        }


        public async Task<BroughtFoward> GetBroughtFowardByCompanyId(int companyId)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);

                var record = conn.QueryFirstOrDefault<BroughtFoward>("[dbo].[usp_Get_Brought_Foward_By_CompanyId]", parameters, commandType: CommandType.StoredProcedure);
                return record;
            }


            return null;
        }




        public async Task<int> CreateAllowableDisAllowable(AllowableDisAllowable allowableDisAllowable)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", allowableDisAllowable.CompanyId);
                parameters.Add("@YearId", allowableDisAllowable.YearId);
                parameters.Add("@TrialBalanceId", allowableDisAllowable.TrialBalanceId);
                parameters.Add("@SelectionId", allowableDisAllowable.SelectionId);
                parameters.Add("@IsAllowable", allowableDisAllowable.IsAllowable);

                rowAffected = con.Execute("[dbo].[Insert_Into_Allowable_DisAllowable]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public async Task<int> CreateBalanceBroughtFoward(BroughtFoward broughtFoward)
        {
            try
            {
                int rowAffected = 0;
                using (IDbConnection con = await _databaseManager.DatabaseConnection())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CompanyId", broughtFoward.CompanyId);
                    parameters.Add("@IsStarted", broughtFoward.IsStarted);
                    parameters.Add("@LossBf", broughtFoward.LossBf);
                    parameters.Add("@LossCf", broughtFoward.LossCf);
                    parameters.Add("@Accessible", 0);
                    parameters.Add("@UnRelievedCf", broughtFoward.UnRelievedCf);
                    parameters.Add("@UnRelievedBf", broughtFoward.UnRelievedBf);
                    rowAffected = con.Execute("[dbo].[usp_Insert_Into_Brought_Foward]", parameters, commandType: CommandType.StoredProcedure);
                }

                return rowAffected;

            }
            catch (Exception ex)
            {

            }
            return 3;
        }



        public async Task<int> UpdateAcessibleByIncomeTax(BroughtFoward broughtFoward)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", broughtFoward.CompanyId);
                parameters.Add("@LossCf", broughtFoward.LossCf);
                parameters.Add("@UnRelievedCf", broughtFoward.UnRelievedCf);
                parameters.Add("@Accessible", broughtFoward.Accessible);
                rowAffected = con.Execute("[dbo].[usp_Accessible_Cf_By_Income_Tax]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }



        public async Task<int> UpdateLossBfById(int companyId)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", companyId);
                rowAffected = con.Execute("[dbo].[usp_Update_lossBf_Background]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }




    }
}