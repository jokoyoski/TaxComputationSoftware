
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Services;

namespace TaxComputationAPI.Manager
{
    public class DatabaseManager
    {
        private readonly ConnectionString _connectionString;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DatabaseManager> _logger;
        public DatabaseManager(IEmailService emailService, IOptions<ConnectionString> connectionString, IWebHostEnvironment webHostEnvironment, ILogger<DatabaseManager> logger)
        {
            _connectionString = connectionString.Value;
            _emailService = emailService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task<IDbConnection> DatabaseConnection() {

            return new SqlConnection(_connectionString.ConnString);

        }


        public List<string> DatabaseScriptList() {
            return new List<string>
            {
                "InvestmentAllowance", "CapitalAllowance", "FixedAsset", "TrialBalance", "BalancingAdjustment", "Utilities", "Company", "PreNotification", "DeferredTax", "IncomeTax", "ProfitAndLoss", "Users"
            };
        }

        public void UpdateProcedure()
        {
           

            SqlConnection conn = new SqlConnection(_connectionString.ConnString);
            try
            {
                _logger.LogInformation("Start running stored procedure scripts");
                conn.Open();
                foreach (var j in DatabaseScriptList())
                {

                    _logger.LogInformation("Running {0} script", j);

                    string path = $"/schema_migrations/{j}.sql";
                    string first_script = File.ReadAllText(_webHostEnvironment.WebRootPath +path );
                    IEnumerable<string> commandStrings = Regex.Split(first_script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {

                            
                            new SqlCommand(commandString, conn).ExecuteNonQuery();
                        }
                        
                    }

                }

            }
            catch (SqlException er)
            {
                _logger.LogError("Could not Connect to Database", er);
                _emailService.Send(AnnualEmailNotificationBackgroundService.LogEmail, AnnualEmailNotificationBackgroundService.AdminEmail, "Application Exception", er.Message, null);
            }
            finally
            {
                conn.Close();
                _logger.LogInformation("Finish running stored procedure scripts");
            }
        }

    }
}
