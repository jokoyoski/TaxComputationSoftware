﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Repositories
{
    public class CapitalAllowanceRepository : ICapitalAllowanceRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<CapitalAllowanceRepository> _logger;

        public CapitalAllowanceRepository(DatabaseManager databaseManager, IEmailService emailService, ILogger<CapitalAllowanceRepository> logger)
        {
            _databaseManager = databaseManager;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<IEnumerable<CapitalAllowance>> GetCapitalAllowance(int assetId, int companyId)
        {

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);
                parameters.Add("@AssetId", assetId);
                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<CapitalAllowance>();
                return result;
            }

            return null;
        }


        public async Task<CapitalAllowance> GetCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);
                parameters.Add("@AssetId", assetId);
                parameters.Add("@Year", year);

                var record = conn.QueryFirstOrDefault<CapitalAllowance>("[dbo].[usp_Get_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]", parameters, commandType: CommandType.StoredProcedure);
                return record;
            }


            return null;
        }

        public async Task<CapitalAllowance> GetArchivedCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);
                parameters.Add("@AssetId", assetId);
                parameters.Add("@Year", year);

                var record = conn.QueryFirstOrDefault<CapitalAllowance>("[dbo].[usp_Get_Archived_Capital_Allowance_By_CompanyId_And_AssetId_And_Year]", parameters, commandType: CommandType.StoredProcedure);
                return record;
            }


            return null;
        }



        public async Task<CapitalAllowance> GetCapitalAllowanceById(int id)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CapitalAllowanceId", id);


                var record = conn.QueryFirstOrDefault<CapitalAllowance>("[dbo].[usp_Get_Capital_Allowance_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                return record;
            }


            return null;
        }


        public async Task<IEnumerable<CapitalAllowanceSummary>> GetCapitalAllowanceSummaryByCompanyId(int id)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", id);


                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_Capital_Allowance_Summary_By_CompanyId]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<CapitalAllowanceSummary>();
                return result;
            }


            return null;
        }


        public async Task<int> UpdateCapitalAllowanceForChannel(string channel, int Id)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Channel", channel);
                parameters.Add("@Id", Id);
                rowAffected = con.Execute("[dbo].[Update_Capital_Allowance_By_Channel]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }


        public async Task<int> UpdateArchivedCapitalAllowanceForChannel(string channel, int companyId, string taxYear, int assetId)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Channel", channel);
                parameters.Add("@CompanyId", companyId);
                parameters.Add("@TaxYear", taxYear);
                parameters.Add("@AssetId", assetId);
                rowAffected = con.Execute("[dbo].[Update_Archived_Capital_Allowance_By_Channel]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }





        public async Task<int> UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(CapitalAllowance capitalAllowance)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TaxYear", capitalAllowance.TaxYear);
                parameters.Add("@OpeningResidue", capitalAllowance.OpeningResidue);
                parameters.Add("@Initial", capitalAllowance.Initial);
                parameters.Add("@Addition", capitalAllowance.Addition);
                parameters.Add("@Disposal", capitalAllowance.Disposal);
                parameters.Add("@Annual", capitalAllowance.Annual);
                parameters.Add("@Total", capitalAllowance.Total);
                parameters.Add("@ClosingResidue", capitalAllowance.ClosingResidue);
                parameters.Add("@YearsToGo", capitalAllowance.YearsToGo);
                parameters.Add("@CompanyId", capitalAllowance.CompanyId);
                parameters.Add("@AssetId", capitalAllowance.AssetId);
                parameters.Add("@CompanyCode", capitalAllowance.CompanyCode);
                parameters.Add("@Channel", capitalAllowance.Channel);
                parameters.Add("@NumberOfYearsAvailable", capitalAllowance.NumberOfYearsAvailable);
                rowAffected = con.Execute("[dbo].[Update_Capital_Allowance_From_Fixed_Asset_Or_Balancing_Adjustment]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }



        public async Task<int> SaveCapitaLAllowanceSummary(CapitalAllowanceSummary capitalAllowance)
        {
            try
            {
                int rowAffected = 0;
                using (IDbConnection con = await _databaseManager.DatabaseConnection())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@OpeningResidue", capitalAllowance.OpeningResidue);
                    parameters.Add("@Addition", capitalAllowance.Addition);
                    parameters.Add("@Disposal", capitalAllowance.Disposal);
                    parameters.Add("@Initial", capitalAllowance.Initial);
                    parameters.Add("@Annual", capitalAllowance.Annual);
                    parameters.Add("@Total", capitalAllowance.Total);
                    parameters.Add("@ClosingResidue", capitalAllowance.ClosingResidue);
                    parameters.Add("@CompanyId", capitalAllowance.CompanyId);
                    parameters.Add("@AssetId", capitalAllowance.AssetId);
                    rowAffected = con.Execute("[dbo].[usp_Insert_Capital_Allowance_Summary]", parameters, commandType: CommandType.StoredProcedure);
                }

                return rowAffected;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }
            return 0;
        }




        public async Task<int> SaveCapitaLAllowance(CapitalAllowance capitalAllowance, string channel)
        {
            try
            {
                int rowAffected = 0;
                using (IDbConnection con = await _databaseManager.DatabaseConnection())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@TaxYear", capitalAllowance.TaxYear);
                    parameters.Add("@OpeningResidue", capitalAllowance.OpeningResidue);
                    parameters.Add("@Addition", capitalAllowance.Addition);
                    parameters.Add("@Disposal", capitalAllowance.Disposal);
                    parameters.Add("@Initial", capitalAllowance.Initial);
                    parameters.Add("@Annual", capitalAllowance.Annual);
                    parameters.Add("@Total", capitalAllowance.Total);
                    parameters.Add("@NumberOfYearsAvailable", capitalAllowance.NumberOfYearsAvailable);
                    parameters.Add("@ClosingResidue", capitalAllowance.ClosingResidue);
                    parameters.Add("@YearsToGo", capitalAllowance.YearsToGo);
                    parameters.Add("@CompanyId", capitalAllowance.CompanyId);
                    parameters.Add("@AssetId", capitalAllowance.AssetId);
                    parameters.Add("@Channel", channel);
                    parameters.Add("@CompanyCode", capitalAllowance.CompanyCode);
                    rowAffected = con.Execute("[dbo].[usp_Insert_Capital_Allowance]", parameters, commandType: CommandType.StoredProcedure);
                }

                return rowAffected;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }
            return 0;
        }
        public async Task DeleteCapitalAllowanceByAssetIdCompanyIdYearId(int companyId, int yearId, int assetId)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", companyId);
                parameters.Add("@Year", yearId);
                parameters.Add("@AssetId", assetId);
                try
                {
                    conn.Execute("[dbo].[usp_Delete_Capital_Allowance_By_Company_Id_YearId_Asset_Id]", parameters, commandType: CommandType.StoredProcedure);
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


        public async Task DeleteCapitalAllowanceSummaryById(int assetId, int companyId)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AssetId", assetId);
                parameters.Add("@CompanyId", companyId);
                try
                {
                    conn.Execute("[dbo].[usp_Delete_Capital_Allowance_Summary_By_AssetId_Commpany_Id]", parameters, commandType: CommandType.StoredProcedure);
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

     



        public async Task<int> SaveArchivedCapitaLAllowance(CapitalAllowance capitalAllowance, string channel)
        {
            try
            {
                int rowAffected = 0;
                using (IDbConnection con = await _databaseManager.DatabaseConnection())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@TaxYear", capitalAllowance.TaxYear);
                    parameters.Add("@OpeningResidue", capitalAllowance.OpeningResidue);
                    parameters.Add("@Addition", capitalAllowance.Addition);
                    parameters.Add("@Disposal", capitalAllowance.Disposal);
                    parameters.Add("@Initial", capitalAllowance.Initial);
                    parameters.Add("@Annual", capitalAllowance.Annual);
                    parameters.Add("@Total", capitalAllowance.Total);
                    parameters.Add("@NumberOfYearsAvailable", capitalAllowance.NumberOfYearsAvailable);
                    parameters.Add("@ClosingResidue", capitalAllowance.ClosingResidue);
                    parameters.Add("@YearsToGo", capitalAllowance.YearsToGo);
                    parameters.Add("@CompanyId", capitalAllowance.CompanyId);
                    parameters.Add("@AssetId", capitalAllowance.AssetId);
                    parameters.Add("@Channel", channel);
                    parameters.Add("@CompanyCode", capitalAllowance.CompanyCode);
                    rowAffected = con.Execute("[dbo].[usp_Insert_Archived_Capital_Allowance]", parameters, commandType: CommandType.StoredProcedure);
                }

                return rowAffected;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }
            return 0;
        }
    }
}
