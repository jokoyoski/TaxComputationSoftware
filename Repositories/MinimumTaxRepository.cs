using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Model;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Repositories
{
    public class MinimumTaxRepository : IMinimumTaxRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<MinimumTaxRepository> _logger;

        public MinimumTaxRepository(DatabaseManager databaseManager, IEmailService emailService, ILogger<MinimumTaxRepository> logger)
        {
            _databaseManager = databaseManager;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYearId(int companyId, int yearId)
        {
            return new MinimumTaxViewDto { turnOver = "220.23", fivePercentTurnOver = "3000.30" };
        }


        public async Task<List<BalancingAdjustment>> GetBalancingAdjustment(int companyId, string year)
        {
            if (companyId <= 0) throw new ArgumentNullException(nameof(companyId));

            if (string.IsNullOrEmpty(year)) throw new ArgumentNullException(nameof(year));

            try
            {
                var result = default(IEnumerable<BalancingAdjustment>);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@CompanyId", companyId);
                    parameters.Add("@Year", year);

                    try
                    {
                        result = await conn.QueryAsync<BalancingAdjustment>("[dbo].[usp_GetBalancingAdjustment_By_CompanyId_And_YearId]", parameters, commandType: CommandType.StoredProcedure);
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                throw new SystemException(e.Message);
            }


        }

        public async Task<MinimumTaxModel> GetMinimumCompanyIdYearId(int companyId, int yearId)
        {
            try
            {
                var result = default(MinimumTaxModel);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@CompanyId", companyId);
                    parameters.Add("@Year", yearId);

                    result = await conn.QueryFirstOrDefaultAsync<MinimumTaxModel>("[dbo].[usp_GetMinimum_By_CompanyId_And_YearId]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();

                    return result;
                }
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                throw new SystemException(e.Message);

            }

        }


        public async Task<MinimumTaxModel> SaveMinimum(MinimumTaxModel minimumTaxDto)

        {
            if (minimumTaxDto == null) throw new ArgumentNullException(nameof(minimumTaxDto));


            try
            {
                var result = default(MinimumTaxModel);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", minimumTaxDto.Id);
                    parameters.Add("@CompanyId", minimumTaxDto.CompanyId);
                    parameters.Add("@GrossProfit", minimumTaxDto.GrossProft);
                    parameters.Add("@NetAsset", minimumTaxDto.NetAsset);
                    parameters.Add("@ShareCapital", minimumTaxDto.ShareCapital);
                    parameters.Add("@TurnOver", minimumTaxDto.TurnOver);
                    parameters.Add("@MinimumTaxPayable", minimumTaxDto.MinimumTaxPayable);
                    parameters.Add("@DateCreated", minimumTaxDto.DateCreated);
                    parameters.Add("@FinancialYearId", minimumTaxDto.FinancialYearId);

                    var respone = conn.Execute("[dbo].[usp_Insert_Minimum_Tax]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();

                    return result = minimumTaxDto;
                }
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                throw new SystemException(e.Message);
            }
        }


        public async Task<MinimumTaxPercentageValue> SaveMinimumPercentage(MinimumTaxPercentageValue minimumTaxDto)
        {
            if (minimumTaxDto == null) throw new ArgumentNullException(nameof(minimumTaxDto));


            try
            {
                var result = default(MinimumTaxModel);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();


                    parameters.Add("@CompanyId", minimumTaxDto.CompanyId);
                    parameters.Add("@YearId", minimumTaxDto.YearId);
                     parameters.Add("@Id", 0);
                    parameters.Add("@MinimumTaxPercentage", minimumTaxDto.MinimumTaxPercentage);
                    var respone = conn.Execute("[dbo].[usp_Insert_Minimum_Tax_Percentage_Table]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();

                    return null;
                }
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                throw new SystemException(e.Message);
            }
        }




        public async Task<MinimumTaxPercentageValue> GetMinimumTaxPercentageCompanyIdYearId(int companyId, int yearId)
        {
            try
            {
                var result = default(MinimumTaxPercentageValue);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@CompanyId", companyId);
                    parameters.Add("@YearId", yearId);

                    result = await conn.QueryFirstOrDefaultAsync<MinimumTaxPercentageValue>("[dbo].[usp_Get_Minimum_Tax_Percentage_By_CompanyId_YearId]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();

                    return result;
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
