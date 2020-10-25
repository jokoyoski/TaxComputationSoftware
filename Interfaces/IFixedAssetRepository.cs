using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;
using TaxComputationAPI.ResponseModel;

namespace TaxComputationAPI.Interfaces
{
    public interface IFixedAssetRepository
    {
           Task<int> SaveFixedAsset ( CreateFixedAssetDto fixedAsset);

           Task <FixedAssetResponse> GetFixedAssetsByCompany(int companyId, int yearId);
    }
}