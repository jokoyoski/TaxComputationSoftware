using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface ICapitalAllowanceRepository
    {
        Task<int> SaveCapitaLAllowance(CapitalAllowance capitalAllowance);

        Task<CapitalAllowance> GetCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year);

        Task<IEnumerable<CapitalAllowance>> GetCapitalAllowance(int assetId, int companyId);

        Task<int> UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(CapitalAllowance capitalAllowance);

        //Task<int> UpdateCapitalAllowanceBybalancingAdjustment(CapitalAllowance capitalAllowance);
    }
}
