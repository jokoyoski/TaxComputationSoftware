using System.Threading.Tasks;
using TaxComputation.Response;
using TaxComputationSoftware.Dto;

namespace TaxComputationSoftware.Interface
{
    public interface IBalancingAdjustmentService
    {
        Task<AddBalancingAdjustmentResponse> AddBalanceAdjustment(AddBalanceAdjustmentDto addBalanceAdjustmentDto);
    }
}