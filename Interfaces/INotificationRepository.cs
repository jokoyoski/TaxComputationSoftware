


using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Model;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<CapitalAllowanceSummary>> GetCapitalAllowanceSummaryByCompanyId(int id);
        Task<int> UpdateArchivedCapitalAllowanceForChannel(string channel, int companyId, string taxYear, int assetId);
        Task<int> UpdateCapitalAllowanceForChannel(string channel, int Id);
        Task<List<PreNotification>> GetPreNotification();

        Task DeleteCapitalAllowanceSummaryById(int assetId, int companyId);

        Task DeleteCapitalAllowanceByAssetIdCompanyIdYearId(int companyId, int yearId, int assetId);

        Task<CapitalAllowance> GetCapitalAllowanceById(int id);
        Task InsertPreNotification(PreNotification preNotification);

        Task<int> SaveCapitaLAllowanceSummary(CapitalAllowanceSummary capitalAllowance);

        Task<int> UpdateDeferredTaxfById(int companyId); //background job

        Task<int> UpdateLossBfById(int companyId);

        Task<int> UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(CapitalAllowance capitalAllowance);
        Task UpdatePreNotification(PreNotification preNotification);
        Task UpdateJobDate(PreNotification preNotification);
        Task<int> SaveCapitaLAllowance(CapitalAllowance capitalAllowance, string channel);

        Task<Company> GetCompanyAsync(int id);
        Task<int> SaveArchivedCapitaLAllowance(CapitalAllowance capitalAllowance, string channel);

        Task<List<AssetMapping>> GetAssetMappingAsync();
        Task<IEnumerable<CapitalAllowance>> GetCapitalAllowance(int assetId, int companyId);
        Task Lock(PreNotification preNotification);
    }
}