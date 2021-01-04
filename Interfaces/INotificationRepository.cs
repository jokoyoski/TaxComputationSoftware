


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
        Task UpdatePreNotification(PreNotification preNotification);
        Task UpdateJobDate(PreNotification preNotification);
        Task<List<AssetMapping>> GetAssetMappingAsync();
        Task<IEnumerable<CapitalAllowance>> GetCapitalAllowance(int assetId, int companyId);
        Task Lock(PreNotification preNotification);
    }
}