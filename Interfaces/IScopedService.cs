using System.Threading;
using System.Threading.Tasks;

namespace Taxcomputation.Interfaces
{
    public interface IScopedProcessingService
    {
        Task SendEmail(CancellationToken stoppingToken);
    }
}