using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;
using TaxComputationAPI.ResponseModel;

namespace TaxComputationAPI.Interfaces
{
    public interface IFixedAssetRepository
    {
        Task<FixedAsset> GetFixedAssetsByCompanyYearIdAssetId(int companyId, int yearId, int assetId);
        Task<int> SaveFixedAsset(CreateFixedAssetDto fixedAsset);
        Task DeleteFixedAssetById(int Id);
        Task<FixedAssetResponse> GetFixedAssetsByCompany(int companyId, int yearId);
    }
}