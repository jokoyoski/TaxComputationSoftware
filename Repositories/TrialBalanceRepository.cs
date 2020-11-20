using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;
using System.Linq;
using TaxComputationAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TaxComputationAPI.Manager;
using Dapper;
using System;
using Microsoft.Extensions.Logging;

namespace TaxComputationAPI.Repositories
{
    public class TrialBalanceRepository : ITrialBalanceRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly ILogger<TrialBalanceRepository> _logger;

        public TrialBalanceRepository(DatabaseManager databaseManager, ILogger<TrialBalanceRepository> logger)
        {
            _databaseManager = databaseManager;
            _logger = logger;
        }

        public async Task UpdateTrialBalance(int trialBalanceId, string mappedTo, bool IsDelete)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@TrailId", trialBalanceId);
                parameters.Add("@mappedTo", mappedTo);
                parameters.Add("@IsDelete", IsDelete);

                try
                {
                    conn.Execute("[dbo].[usp_UpdateTrialBalance]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");
                    throw e;
                }
            }
        }

        public async Task<TrackTrialBalance> GetTrackTrialBalance(int companyId, int yearId)
        {
            var result = default(TrackTrialBalance);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@YearId", yearId);
                parameters.Add("@CompanyId", companyId);

                try
                {
                    result = conn.QueryFirstOrDefault<TrackTrialBalance>("[dbo].[usp_GetTrackTrialBalance_By_CompanyId_And_YearId]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result;
            }
        }

        public async Task<List<TrialBalance>> GetTrialBalance(int trackId)
        {
            var result = default(IEnumerable<TrialBalance>);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@TrackId", trackId);

                try
                {
                    result = await conn.QueryAsync<TrialBalance>("[dbo].[usp_GetTrialBalance_By_TrackingId]", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<TrackTrialBalance> AddTrackTrialBalance(TrackTrialBalance model)
        {
            var result = default(TrackTrialBalance);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", model.Id);
                parameters.Add("@CompanyId", model.CompanyId);
                parameters.Add("@YearId", model.YearId);
                parameters.Add("@DateCreated", model.DateCreated);

                try
                {
                    var respone = conn.Execute("[dbo].[usp_Insert_Track_Trial_Balance]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result = model;
            }
        }

        public async Task<TrialBalance> RemoveTrackTrialBalance(TrialBalance trialBalance)
        {
            var result = default(TrialBalance);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();


                parameters.Add("@TrailId", trialBalance.Id);

                try
                {
                    var respone = conn.Execute("[dbo].[usp_DeleteTrialBalance_By_Id]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result;
            }
        }

        public async Task<TrialBalance> UploadTrialBalance(TrialBalance model)
        {
             var result = default(TrialBalance);

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", model.Id);
                parameters.Add("@Item", model.Item);
                parameters.Add("@Debit", model.Debit);
                parameters.Add("@Credit", model.Credit);
                parameters.Add("@MappedTo", model.MappedTo);
                parameters.Add("@IsCheck", model.IsCheck);
                parameters.Add("@AccountId", model.AccountId);
                parameters.Add("@TrackId", model.TrackId);
                parameters.Add("@IsRemoved", model.IsRemoved);


                try
                {
                    var respone = conn.Execute("[dbo].[usp_Insert_Trial_Balance]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                catch (Exception e)
                {
                    _logger.LogError($"{e.Message}");

                    throw e;
                }

                return result = model;
            }
        }
    }
}
