
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

namespace TaxComputationAPI.Manager
{
    public class DatabaseManager
    {
        private readonly ConnectionString _connectionString;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DatabaseManager> _logger;
        public DatabaseManager(IOptions<ConnectionString> connectionString, IWebHostEnvironment webHostEnvironment, ILogger<DatabaseManager> logger)
        {
            _connectionString = connectionString.Value;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task<IDbConnection> DatabaseConnection() {

            return new SqlConnection(_connectionString.ConnString);

        }


        public List<string> DatabaseScriptList() {
            return new List<string>
            {
                "CapitalAllowance"
            };
        }

        public void UpdateProcedure()
        {
           

            SqlConnection conn = new SqlConnection(_connectionString.ConnString);
            try
            {
                conn.Open();
                foreach (var j in DatabaseScriptList())
                {

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
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
