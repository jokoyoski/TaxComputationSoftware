using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUtilitiesRepository
    {
        Task DeleteAllowableDisAllowableById(int Id);
        Task<AllowableDisAllowable> GetAllowableDisAllowableById(int Id);
        Task<FinancialYear> GetFinancialYearAsync(int yearId);
        Task<AllowableDisAllowable> GetAllowableDisAllowableByTrialBalanceId(int Id);

        Task<decimal> GetAmount(int moduleId, string additionalInfo);

        Task<List<FinancialYear>> GetFinancialYearAsync();

        Task AddFinancialYearAsync(FinancialYear financialClass);

        Task<List<AssetMapping>> GetAssetMappingAsync();

        Task<AssetMapping> GetAssetMappingAsync(string Name);

        Task<AssetMapping> GetAssetMappingById(int Id);

        Task AddAssetMappingAsync(AssetMapping asset);

        Task UpdateAssetMappingAsync(AssetMapping asset);

        Task DeleteAssetMappingAsync(int id);

        Task AddTrialBalanceMapping(int trialBalanceId, int moduleId, string moduleCode, string additionalInfo);

        Task DeleteTrialBalancingMapping(int trialBalanceId);

        Task AddCompanyCode(CompanyCode companyCode);

        Task<CompanyCode> GetCompanyCodeByCodeId(int companyId);

        Task DeleteFairGainByTrialBalanceId(int Id);
    }
}
