using TaxComputationAPI.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaxComputationAPI.Models;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;
using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;

namespace TaxComputationAPI.Repositories
{
    public class BalancingAdjustmentRepository : IBalancingAdjustmentRepository
    {
        private readonly DatabaseManager _databaseManager;
        private readonly ILogger<BalancingAdjustment> _logger;

        public BalancingAdjustmentRepository(DatabaseManager databaseManger, ILogger<BalancingAdjustment> logger)
        {
            _databaseManager = databaseManger;
            _logger = logger;
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
                throw new SystemException(e.Message);
            }


        }

          public async Task<BalancingAdjustment> GetBalancingAdjustmentById(int balancingAdjustmentId)
         {

            if (balancingAdjustmentId <= 0) throw new ArgumentNullException(nameof(balancingAdjustmentId));

          
            try
            {
                var result = default(BalancingAdjustment);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    
                    parameters.Add("@Id", balancingAdjustmentId);

                    try
                    {
                        result = await conn.QueryFirstOrDefaultAsync<BalancingAdjustment>("[dbo].[usp_GetBalancingAdjustment_By_Id]", parameters, commandType: CommandType.StoredProcedure);
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
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }

        }



        public async Task<List<BalancingAdjustmentYearBought>> GetBalancingAdjustmentYearBougthAssetId(int balancingAdjustmentId, int assetId)
        {
            if (balancingAdjustmentId <= 0) throw new ArgumentNullException(nameof(balancingAdjustmentId));

            if (assetId <= 0) throw new ArgumentNullException(nameof(assetId));

            try
            {
                var result = default(IEnumerable<BalancingAdjustmentYearBought>);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@BalancingAdjustmentId", balancingAdjustmentId);
                    parameters.Add("@AssetId", assetId);

                    try
                    {
                        result = await conn.QueryAsync<BalancingAdjustmentYearBought>("[dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId]", parameters, commandType: CommandType.StoredProcedure);
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
                throw new SystemException(e.Message);
            }
        }

        public async Task<List<BalancingAdjustmentYearBought>> GetBalancingAdjustmentYeatBought(int balancingAdjustmentId, int assetId)
        
        {

            if (balancingAdjustmentId <= 0) throw new ArgumentNullException(nameof(balancingAdjustmentId));

            if (assetId <= 0) throw new ArgumentNullException(nameof(assetId));

            try
            {
                var result = default(IEnumerable<BalancingAdjustmentYearBought>);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@BalancingAdjustmentId", balancingAdjustmentId);
                    parameters.Add("@AssetId", assetId);

                    try
                    {
                        result = await conn.QueryAsync<BalancingAdjustmentYearBought>("[dbo].[usp_GetBalancingAdjustment_BalancingAdjustmentId_AssetId]", parameters, commandType: CommandType.StoredProcedure);
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
                throw new SystemException(e.Message);
            }

        }

        public async Task<BalancingAdjustment> SaveBalancingAdjustment(BalancingAdjustment balancingAdjustment)
        {
            if (balancingAdjustment == null) throw new ArgumentNullException(nameof(balancingAdjustment));

            try
            {
                var result = default(BalancingAdjustment);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", balancingAdjustment.Id);
                    parameters.Add("@AssetId", balancingAdjustment.AssetId);
                    parameters.Add("@CompanyId", balancingAdjustment.CompanyId);
                    parameters.Add("@Year", balancingAdjustment.Year);
                    parameters.Add("@DateCreated", balancingAdjustment.DateCreated);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Insert_Balance_Adjustment]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"{e.Message}");

                        throw e;
                    }

                    return result = balancingAdjustment;
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }

        public async Task<BalancingAdjustmentYearBought> SaveBalancingAdjustmentYeatBought(BalancingAdjustmentYearBought balancingAdjustmentYearBought)
        {
            if (balancingAdjustmentYearBought == null) throw new ArgumentNullException(nameof(balancingAdjustmentYearBought));

          
            try
            {
                var result = default(BalancingAdjustmentYearBought);

                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", balancingAdjustmentYearBought.Id);
                    parameters.Add("@AssestId", balancingAdjustmentYearBought.AssestId);
                    parameters.Add("@Cost", balancingAdjustmentYearBought.Cost);
                    parameters.Add("@InitialAllowance", balancingAdjustmentYearBought.InitialAllowance);
                    parameters.Add("@AnnualAllowance", balancingAdjustmentYearBought.AnnualAllowance);
                    parameters.Add("@SalesProceed", balancingAdjustmentYearBought.SalesProceed);
                    parameters.Add("@Residue", balancingAdjustmentYearBought.Residue);
                    parameters.Add("@BalancingAllowance", balancingAdjustmentYearBought.BalancingAllowance);
                    parameters.Add("@BalancingCharge", balancingAdjustmentYearBought.BalancingCharge);
                    parameters.Add("@YearBought", balancingAdjustmentYearBought.YearBought);
                    parameters.Add("@BalancingAdjustmentId", balancingAdjustmentYearBought.BalancingAdjustmentId);
                    parameters.Add("@DateCreated", balancingAdjustmentYearBought.DateCreated);

                    try
                    {
                        var respone = conn.Execute("[dbo].[usp_Insert_Balance_Adjustment_YearBought]", parameters, commandType: CommandType.StoredProcedure);
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"{e.Message}");

                        throw e;
                    }

                    return result = balancingAdjustmentYearBought;
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message);
            }
        }
    }
}