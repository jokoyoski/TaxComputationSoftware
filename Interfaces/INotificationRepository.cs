


using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Model;

namespace TaxComputationSoftware.Interfaces
{
    public interface INotificationRepository
    {
        Task<int> UpdateArchivedCapitalAllowanceForChannel(string channel, int companyId, string taxYear, int assetId);
        Task<int> UpdateCapitalAllowanceForChannel(string channel, int Id);
        Task<List<PreNotification>> GetPreNotification();
        Task InsertPreNotification(PreNotification preNotification);

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