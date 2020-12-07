using System.Threading.Tasks;
using TaxComputationAPI.Response;
using TaxComputationAPI.Dto;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IBalancingAdjustmentService
    {
        Task<AddBalancingAdjustmentResponse> AddBalanceAdjustment(AddBalanceAdjustmentDto addBalanceAdjustmentDto);
        Task<AddBalancingAdjustmentResponse> DisplayBalancingAdjustment(int companyId, string year);
        Task DeleteBalancingAdjustmentYearBoughtAsync(BalancingAdjustmentYearBought balancingAdjustmentYearBought);
        Task<BalancingAdjustmentYearBought> GetBalancingAdjustmentYearBoughtById(int Id);


    }
}