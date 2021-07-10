using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;

namespace TaxComputationAPI.Interfaces
{
    public interface ICapitalAllowanceService
    {
        Task<IEnumerable<CapitalAllowance>> GetCapitalAllowanceByCompanyId(int id);
        Task SaveCapitalAllowance(CapitalAllowance capitalAllowance);
        Task SaveCapitalAllowanceSummary(int assetId, int companyId);

        Task DeleteCapitalAllowanceById(int TrialBalanceId);

        Task<decimal> GetCapitalAllowanceSummaryForIncomeTax(int companyId);

        Task<CapitalAllowanceDto> GetCapitalAllowance(int assetId, int companyId);

        Task<int> SaveCapitalAllowanceFromFixedAsset(decimal addition, string year, int companyId, int assetId, decimal disposal);

        Task UpdateCapitalAllowanceFromDeleteBalancingAdjustment(decimal residue, string year, int companyId, int assetId);

        Task<int> SaveCapitalAllowanceFromBalancingAdjustment(decimal residue, string year, int companyId, int assetId);

        Task<CapitalAllowance> GetCapitalAllowanceByAssetIdYear(int assetId, int companyId, string year);

        Task<List<CapitalAllowanceSummaryDto>> GetCapitalAllowanceSummaryByCompanyId(int companyId);

        Task<decimal> GetCapitalAllowanceSummaryForDeferredTax(int companyId);

        Task<int> UpdateCapitalAllowanceForChannel(string channel, int Id);

        Task<int> UpdateArchivedCapitalAllowanceForChannel(string channel, int companyId, string taxYear, int assetId);

    }
}
