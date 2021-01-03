


using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationSoftware.Model;

namespace TaxComputationSoftware.Interfaces
{
    public interface INotificationRepository
    {
        Task<List<PreNotification>> GetPreNotification();
        Task InsertPreNotification(PreNotification preNotification);
        Task UpdatePreNotification(PreNotification preNotification);
        Task UpdateJobDate(PreNotification preNotification);
        Task Lock(PreNotification preNotification);
    }
}