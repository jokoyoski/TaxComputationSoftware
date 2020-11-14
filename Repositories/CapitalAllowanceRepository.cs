using System;
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
                var record = await conn.QueryMultipleAsync("dbo].[usp_Get_Capital_Allowance_By_CompanyId_Year]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<CapitalAllowance>();
                return result;
            }

             return null;
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
 