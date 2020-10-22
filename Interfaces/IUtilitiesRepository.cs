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
        Task<FinancialYear> GetFinancialYearAsync(int yearId);
        Task AddAssetClassAsync(AssetClass assetClass);
        Task<List<FinancialYear>> GetFinancialYearAsync();
        Task AddFinancialYearAsync(FinancialYear financialClass);

        Task<List<AssetMapping>> GetAssetMappingAsync();
        Task<AssetMapping> GetAssetMappingAsync(string Name);
        Task<AssetMapping> GetAssetMappingById(int Id);
        Task AddAssetMappingAsync(AssetMapping asset);
        Task UpdateAssetMappingAsync(AssetMapping asset);
    }
}
