using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUtilitiesService
    {

        Task<List<AssetClass>> GetAssetClassAsync();

        Task<AssetClass> GetAssetClassAsync(string Name);

        Task<FinancialYear> GetFinancialYearAsync(int Name);
        Task AddAssetClassAsync(AssetClass assetClass);
        Task<List<FinancialYear>> GetFinancialYearAsync();
        Task AddFinancialYearAsync(FinancialYear financialYear);

        Task<List<AssetMapping>> GetAssetMappingAsync();
        Task<AssetMapping> GetAssetMappingAsync(string Name);
        Task<AssetMapping> GetAssetMappingById(int Id);
        Task AddAssetMappingAsync(AssetMapping assetMapping);

        Task UpdateAssetMappingAsync(AssetMapping assetMapping);
    }
}
