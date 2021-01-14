


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Model;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Repositories
{

    public class NotificationRepository : INotificationRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly ILogger<NotificationRepository> _logger;

        public NotificationRepository(DatabaseManager databaseManager, ILogger<NotificationRepository> logger)
        {
            _databaseManager = databaseManager;
            _logger = logger;
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

        public async Task<List<AssetMapping>> GetAssetMappingAsync()
        {
            var result = default(IEnumerable<AssetMapping>);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                try
                {
                    result = await conn.QueryAsync<AssetMapping>("[dbo].[usp_Get_Asset_Mapping]", parameters, commandType: CommandType.StoredProcedure);
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

            }
            return 0;
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

        public async Task<List<PreNotification>> GetPreNotification()
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                try
                {
                    var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_All_PreNotification]", null, commandType: CommandType.StoredProcedure);
                    var result = await record.ReadAsync<PreNotification>();
                    conn.Close();
                    return result.ToList();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");
                    throw e;
                }
            }

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

            }
            return 0;
        }

        public async Task InsertPreNotification(PreNotification preNotification)
        {
            if (preNotification == null) throw new ArgumentNullException(nameof(preNotification));

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", preNotification.Id);
                parameters.Add("@CompanyId", preNotification.CompanyId);
                parameters.Add("@OpeningDate", preNotification.OpeningDate);
                parameters.Add("@ClosingDate", preNotification.ClosingDate);
                parameters.Add("@IsLocked", false);

                try
                {
                    var respone = conn.Execute("[dbo].[usp_Insert_PreNotification]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                    var tim = preNotification;
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");
                    throw e;
                }
            }
        }

        public async Task UpdatePreNotification(PreNotification preNotification)
        {
            if (preNotification == null) throw new ArgumentNullException(nameof(preNotification));

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", preNotification.Id);
                parameters.Add("@OpeningDate", preNotification.OpeningDate);
                parameters.Add("@ClosingDate", preNotification.OpeningDate);
                parameters.Add("@JobDate", preNotification.JobDate);

                try
                {
                    var respone = conn.Execute("[dbo].[usp_UpdatePreNotification]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");
                    throw e;
                }
            }
        }

        public async Task UpdateJobDate(PreNotification preNotification)
        {
            if (preNotification == null) throw new ArgumentNullException(nameof(preNotification));

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", preNotification.Id);

                try
                {
                    var respone = conn.Execute("[dbo].[usp_Update_Jobdate_To_Null]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");
                    throw e;
                }
            }
        }

        public async Task Lock(PreNotification preNotification)
        {
            if (preNotification == null) throw new ArgumentNullException(nameof(preNotification));

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", preNotification.Id);
                parameters.Add("@IsLocked", preNotification.IsLocked);

                try
                {
                    var respone = conn.Execute("[dbo].[usp_Lock]", parameters, commandType: CommandType.StoredProcedure);
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