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
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<CompaniesRepository> _logger;

        public CompaniesRepository(DatabaseManager databaseManager, IEmailService emailService, ILogger<CompaniesRepository> logger)
        {
            _databaseManager = databaseManager;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Company> GetCompanyAsync(int id)
        {


            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", id);

                var record = await conn.QueryFirstAsync<Company>("[dbo].[usp_Get_Company_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                return record;
            }


        }

        public async Task<Company> GetCompanyByTinAsync(string tinNumber)
        {
            try
            {
                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@TinNumber", tinNumber);

                    var record = conn.QueryFirstOrDefault<Company>("[dbo].[usp_Get_Company_By_Tin]", parameters, commandType: CommandType.StoredProcedure);
                    return record;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }

            return null;
        }



        public async Task AddCompanyAsync(Company company)
        {
            try
            {
                int rowAffected = 0;
                using (IDbConnection con = await _databaseManager.DatabaseConnection())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CompanyName", company.CompanyName);
                    parameters.Add("@CompanyDescription", company.CompanyDescription);
                    parameters.Add("@CacNumber", company.CompanyDescription);
                    parameters.Add("@TinNumber", company.TinNumber);
                    parameters.Add("@DateCreated", company.DateCreated);
                    parameters.Add("@OpeningYear", company.OpeningYear);
                    parameters.Add("@ClosingYear", company.ClosingYear);
                    parameters.Add("@IsActive", company.IsActive);
                    parameters.Add("@MonthOfOperation", company.MonthOfOperation);
                    rowAffected = con.Execute("[dbo].[usp_Insert_Company]", parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }
      

        }





        public async Task<PagedList<Company>> GetCompaniesAsync(PaginationParams pagination)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_All_Company]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<Company>();
                return await PagedList<Company>.CreateAsync(result, pagination.PageNumber, pagination.PageSIze);
            }

        }

         public async Task DeleteCompany(int Id)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                try
                {
                    conn.Execute("[dbo].[usp_Delete_Company]", parameters, commandType: CommandType.StoredProcedure);
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




        public async Task<object> GetCompanyInfoByFinancialYear(int companyId, int financialYearId)
        {
            try
            {
                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@CompanyId", companyId);
                    parameters.Add("@FinancialYearId", financialYearId);

                    var record = conn.QueryFirstOrDefault<object>("[dbo].[usp_Get_Company_By_CompanyId_FinancialYearId]", parameters, commandType: CommandType.StoredProcedure);
                    return record;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
            }

            return null;
        }
    }
}
