using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUtilitiesService
    {


        Task<FinancialYear> GetFinancialYearAsync(int Name);
        Task<List<FinancialYear>> GetFinancialYearAsync();
        Task AddFinancialYearAsync(FinancialYear financialYear);

        Task<List<AssetMapping>> GetAssetMappingAsync();
        Task<AssetMapping> GetAssetMappingAsync(string Name);
        Task<AssetMapping> GetAssetMappingById(int Id);
        Task AddAssetMappingAsync(AssetMapping assetMapping);

         Task<List<ModuleTypeDto>> GetModuleMappingbyCode(string code);

        Task UpdateAssetMappingAsync(AssetMapping assetMapping);
        Task DeleteAssetMappingAsync(int id);

        Task UnmapValue(int trialBalanceId);
 
       

    }
}
