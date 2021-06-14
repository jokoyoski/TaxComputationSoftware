using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Model;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUtilitiesRepository
    {
        //Task AddRollBackAsync(RollBackYear rollBackYear);
         Task<RollBackYear> GetRollBackYear(int companyId);
        Task<FinancialYear> GetLastFinancialYearAsync(int companyId);
        Task DeleteLastFinancialYearAsync(int yearId);
        Task DeleteAllowableDisAllowableById(int Id);
        Task<AllowableDisAllowable> GetAllowableDisAllowableById(int Id);
        Task<FinancialYear> GetFinancialYearAsync(int yearId);
        Task<AllowableDisAllowable> GetAllowableDisAllowableByTrialBalanceId(int Id);

        Task<decimal> GetAmount(int moduleId, string additionalInfo);

        Task<List<FinancialYear>> GetFinancialYearAsync();

        Task<List<FinancialYear>> GetFinancialCompanyAsync(int companyId);

        Task AddFinancialYearAsync(FinancialYear financialClass);

        Task UpdateFinancialYearAsync(FinancialYear financialYear);

        Task DeleteFinancialYearAsync(FinancialYear financialYear);

        Task<List<AssetMapping>> GetAssetMappingAsync();

        Task<AssetMapping> GetAssetMappingAsync(string Name);

        Task<AssetMapping> GetAssetMappingById(int Id);

        Task AddAssetMappingAsync(AssetMapping asset);

        Task AddRollBackAsync(RollBackYear rollBackYear);

        Task UpdateAssetMappingAsync(AssetMapping asset);

        Task DeleteAssetMappingAsync(int id);

        Task AddTrialBalanceMapping(int trialBalanceId, int moduleId, string moduleCode, string additionalInfo);

        Task DeleteTrialBalancingMapping(int trialBalanceId);

        Task AddCompanyCode(CompanyCode companyCode);

        Task<CompanyCode> GetCompanyCodeByCodeId(int companyId);

        Task DeleteFairGainByTrialBalanceId(int Id);

        Task<List<PreNotification>> GetPreNotification();
    }
}
