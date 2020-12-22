using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface ICapitalAllowanceRepository
    {
        Task<int> SaveCapitaLAllowance(CapitalAllowance capitalAllowance, string channel);
        Task DeleteCapitalAllowanceById(int TrialBalanceId);

        Task<CapitalAllowance> GetCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year);

        Task<IEnumerable<CapitalAllowance>> GetCapitalAllowance(int assetId, int companyId);

        Task<int> UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(CapitalAllowance capitalAllowance);

        Task<int> SaveArchivedCapitaLAllowance(CapitalAllowance capitalAllowance, string channel);

        Task<CapitalAllowance> GetArchivedCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year);

        Task<CapitalAllowance> GetCapitalAllowanceById(int id);

        Task<int> SaveCapitaLAllowanceSummary(CapitalAllowanceSummary capitalAllowance);

        Task<IEnumerable<CapitalAllowanceSummary>> GetCapitalAllowanceSummaryByCompanyId(int id);


    }
}
