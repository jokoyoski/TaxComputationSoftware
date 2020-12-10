using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface ICapitalAllowanceService
    {
        Task<int> SaveCapitalAllowance(CapitalAllowance capitalAllowance);

        Task<CapitalAllowanceDto> GetCapitalAllowance(int assetId, int companyId);

        Task<int> SaveCapitalAllowanceFromFixedAsset(decimal addition, string year, int companyId, int assetId);

        Task UpdateCapitalAllowanceFromDeleteBalancingAdjustment(decimal residue, string year, int companyId, int assetId);

        Task<int> SaveCapitalAllowanceFromBalancingAdjustment(decimal residue, string year, int companyId, int assetId);
    }
}
