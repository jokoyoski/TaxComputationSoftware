using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.ResponseModel;

namespace TaxComputationAPI.Interfaces
{
    public interface IFixedAssetService
    {
         Task SaveFixedAsset ( CreateFixedAssetDto fixedAsset);


         Task<FixedAssetResponse> GetFixedAssetsByCompany(int companyId, int yearId);
    }
}