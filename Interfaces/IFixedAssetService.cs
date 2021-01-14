using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;
using TaxComputationAPI.ResponseModel;

namespace TaxComputationAPI.Interfaces
{
    public interface IFixedAssetService
    {
        Task SaveFixedAsset(CreateFixedAssetDto fixedAsset);
        // decimal GetAmount(string type, List<int> trialBalance);
        Task DeleteFixedAsset(int fixedAssetId);

        Task DeleteFixedAssetById(int Id);
        Task<decimal> GetFixedAssetsByCompanyForDeferredTax(int companyId, int yearId);

        Task<decimal> GetAmount(List<int> trialBalances, bool isCost);
        Task<TaxComputationAPI.Dtos.FixedAssetResponseDto> GetFixedAssetsByCompany(int companyId, int yearId);
    }
}