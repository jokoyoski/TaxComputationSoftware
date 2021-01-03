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
        Task DeleteCapitalAllowanceByAssetIdCompanyIdYearId(int companyId, int yearId, int assetId);
        Task<CapitalAllowance> GetCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year);
        Task<int> UpdateCapitalAllowanceForChannel(string channel, int Id);

        Task<IEnumerable<CapitalAllowance>> GetCapitalAllowance(int assetId, int companyId);

        Task<int> UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(CapitalAllowance capitalAllowance);

        Task<int> SaveArchivedCapitaLAllowance(CapitalAllowance capitalAllowance, string channel);

        Task DeleteCapitalAllowanceSummaryById(int assetId, int companyId);

        Task<CapitalAllowance> GetArchivedCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year);

        Task<CapitalAllowance> GetCapitalAllowanceById(int id);

        Task<int> SaveCapitaLAllowanceSummary(CapitalAllowanceSummary capitalAllowance);

        Task<IEnumerable<CapitalAllowanceSummary>> GetCapitalAllowanceSummaryByCompanyId(int id);

        Task<int> UpdateArchivedCapitalAllowanceForChannel(string channel, int companyId, string taxYear, int assetId);


    }
}
