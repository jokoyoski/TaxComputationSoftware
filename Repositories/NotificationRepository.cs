


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Manager;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Model;

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


        public async Task InsertPreNotification(PreNotification preNotification)
        {
            if (preNotification == null) throw new ArgumentNullException(nameof(preNotification));

            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", preNotification.Id);
                parameters.Add("@OpeningDate", preNotification.OpeningDate);

                try
                {
                    var respone = conn.Execute("[dbo].[usp_Insert_PreNotification]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
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

    }
}