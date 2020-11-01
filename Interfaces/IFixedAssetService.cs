using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.ResponseModel;

namespace TaxComputationAPI.Interfaces
{
    public interface IFixedAssetService
    {
         Task SaveFixedAsset ( CreateFixedAssetDto fixedAsset);

          Task DeleteFixedAsset (int fixedAssetId);
         Task<TaxComputationAPI.Dtos.FixedAssetResponseDto> GetFixedAssetsByCompany(int companyId, int yearId);
    }
}