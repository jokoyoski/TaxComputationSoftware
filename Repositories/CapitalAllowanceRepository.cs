﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class CapitalAllowanceRepository : ICapitalAllowanceRepository
    {
        private readonly DatabaseManager _databaseManager;
        public CapitalAllowanceRepository(DatabaseManager databaseManager) {
            _databaseManager = databaseManager;
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


        public async Task<CapitalAllowance> GetCapitalAllowanceByAssetIdYear(int assetId, int companyId,string year)
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


        public async Task<int> UpdateCapitalAllowanceByFixedAsset(CapitalAllowance capitalAllowance)
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
                parameters.Add("@Annual", capitalAllowance.Annual);
                parameters.Add("@Total", capitalAllowance.Total);
                parameters.Add("@ClosingResidue", capitalAllowance.ClosingResidue);
                parameters.Add("@YearsToGo", capitalAllowance.YearsToGo);
                parameters.Add("@CompanyId", capitalAllowance.CompanyId);
                parameters.Add("@AssetId", capitalAllowance.AssetId);
                rowAffected = con.Execute("[dbo].[Update_Capital_Allowance_From_Fixed_Asset]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }



        public async Task<int> UpdateCapitalAllowanceBybalancingAdjustment(CapitalAllowance capitalAllowance)
        {
            int rowAffected = 0;
            using (IDbConnection con = await _databaseManager.DatabaseConnection())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TaxYear", capitalAllowance.TaxYear);
                parameters.Add("@OpeningResidue", capitalAllowance.OpeningResidue);
                parameters.Add("@ClosingResidue", capitalAllowance.ClosingResidue);
                parameters.Add("@CompanyId", capitalAllowance.CompanyId);
                parameters.Add("@AssetId", capitalAllowance.AssetId);
                rowAffected = con.Execute("[dbo].[Update_Capital_Allowance_From_Balancing_Ajustment]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }


        public async Task<int> SaveCapitaLAllowance(CapitalAllowance capitalAllowance)
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
                parameters.Add("@ClosingResidue", capitalAllowance.ClosingResidue);
                parameters.Add("@YearsToGo", capitalAllowance.YearsToGo);
                parameters.Add("@CompanyId", capitalAllowance.CompanyId);
                parameters.Add("@AssetId", capitalAllowance.AssetId);
                rowAffected = con.Execute("[dbo].[usp_Insert_Capital_Allowance]", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}
 