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
        Task DeleteAssetMappingAsync(AssetMapping assetMapping);

        Task<List<ItemsMapping>> GetItemsMappingAsync();
        Task<ItemsMapping> GetItemsMappingByMappedCode(string MappedCode);
        Task<ItemsMapping> GetItemsMappingById(int Id);
        Task AddItemsMappingAsync(ItemsMapping assetMapping);

        Task UpdateItemsMappingAsync(ItemsMapping assetMapping);
        Task DeleteItemsMappingAsync(ItemsMapping assetMapping);
    }
}
