using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUtilitiesRepository
    {
        Task<List<AssetClass>> GetAssetClassAsync();
        Task<AssetClass> GetAssetClassAsync(string Name);
        Task<FinancialYear> GetFinancialYearAsync(string Name);
        Task AddAssetClassAsync(AssetClass assetClass);
        Task<List<FinancialYear>> GetFinancialYearAsync();
        Task AddFinancialYearAsync(FinancialYear financialClass);
    }
}
