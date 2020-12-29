


using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationSoftware.Model;

namespace TaxComputationSoftware.Interfaces
{
    public interface INotificationRepository
    {
        Task<List<PreNotification>> GetPreNotification();
        Task UpdatePreNotification(PreNotification preNotification);
    }
}