using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Repositories
{
    public class InvestmentAllowanceRepository : IInvestmentAllowanceRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<UtilitiesRepository> _logger;

        public InvestmentAllowanceRepository(DatabaseManager databaseManager, IEmailService emailService, ILogger<UtilitiesRepository> logger)
        {
            _databaseManager = databaseManager;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task AddInvestmentAllowanceAsync(InvestmentAllowance investmentAllowance)
        {
            if (investmentAllowance == null) throw new ArgumentNullException(nameof(investmentAllowance));

            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@AssetId", investmentAllowance.AssetId);

                    parameters.Add("@YearId", investmentAllowance.YearId);

                    parameters.Add("@CompanyId", investmentAllowance.CompanyId);


                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Insert_Investment_Allowance]", parameters, commandType: CommandType.StoredProcedure);
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
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }

        public async Task DeleteInvestmentAllowanceAsync(int Id)
        {

            
            try
            {

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();


                    DynamicParameters parameters = new DynamicParameters();


                    parameters.Add("@Id", Id);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Delete_Investment_Allowance]", parameters, commandType: CommandType.StoredProcedure);
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
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }

         public async Task<List<InvestmentAllowance>> GetInvestmentAlowanceByCompanyIdYearId(int companyId, int yearId)
         {
            var result = default(IEnumerable<InvestmentAllowance>);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);
                parameters.Add("@YearId", yearId);

                try
                {
                    result = await conn.QueryAsync<InvestmentAllowance>("[dbo].[usp_Get_Investment_Allowance_By_CompanyId_YearId]", parameters, commandType: CommandType.StoredProcedure);
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

    }
}
