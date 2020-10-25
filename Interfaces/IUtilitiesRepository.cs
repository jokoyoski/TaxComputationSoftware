using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUtilitiesRepository
    {
       
        Task<FinancialYear> GetFinancialYearAsync(int yearId);
        
        decimal GetAmount(int moduleId, string additionalInfo);
        Task<List<FinancialYear>> GetFinancialYearAsync();
        Task AddFinancialYearAsync(FinancialYear financialClass);

        Task<List<AssetMapping>> GetAssetMappingAsync();
        Task<AssetMapping> GetAssetMappingAsync(string Name);
        Task<AssetMapping> GetAssetMappingById(int Id);
        Task AddAssetMappingAsync(AssetMapping asset);
        Task UpdateAssetMappingAsync(AssetMapping asset);
        Task DeleteAssetMappingAsync(AssetMapping asset);

      
        void  AddTrialBalanceMapping (int trialBalanceId, int moduleId,string moduleCode,string additionalInfo);

        void  DeleteTrialBalancingMapping(int trialBalanceId);
    }
}
