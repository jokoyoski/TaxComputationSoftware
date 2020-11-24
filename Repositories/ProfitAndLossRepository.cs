using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Repositories
{
    public class ProfitAndLossRepository : IProfitAndLossRepository
    {
        private readonly DatabaseManager _databaseManager;
        private   readonly ILogger<ProfitAndLossRepository> _logger;
        public ProfitAndLossRepository(DatabaseManager databaseManager,ILogger<ProfitAndLossRepository> logger)
        {
            _databaseManager = databaseManager;
            _logger=logger;
        }

     

       public async Task<ProfitAndLoss> GetProfitAndLossByCompanyIdAndYearId(int companyId,int yearId)
        {
            try
            {
                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@YearId", yearId);
                    parameters.Add("@CompanyId", companyId);


                    var record =  conn.QueryFirstOrDefault<ProfitAndLoss>("[dbo].[usp_Get_Profit_And_Loss_By_YearId_CompanyId]", parameters, commandType: CommandType.StoredProcedure);
                    return record;
                }
            }
            catch (Exception ex) {


            }

            return null;
        }


         public async Task UpdateProfitAndLoss(AddProfitAndLoss addProfitAndLoss)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@YearId", addProfitAndLoss.YearId);
                parameters.Add("@CompanyId", addProfitAndLoss.CompanyId);
                parameters.Add("@Type", addProfitAndLoss.Type);
                parameters.Add("@Amount", addProfitAndLoss.Amount);



                try
                {
                    conn.Execute("[dbo].[usp_Update_Profit_And_Loss_By_YearId_CompanyId]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");
                    throw e;
                }
            }
        }


    }
}
