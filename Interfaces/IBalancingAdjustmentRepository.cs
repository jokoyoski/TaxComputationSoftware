using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IBalancingAdjustmentRepository
    {
        Task<List<BalancingAdjustment>> GetBalancingAdjustment(int companyId, string year);
        Task<List<BalancingAdjustmentYearBought>> GetBalancingAdjustmentYeatBought(int balancingAdjustmentId, int asssetId);
        Task<BalancingAdjustment> SaveBalancingAdjustment(BalancingAdjustment balancingAdjustment);
        Task<BalancingAdjustmentYearBought> SaveBalancingAdjustmentYeatBought(BalancingAdjustmentYearBought balancingAdjustmentYearBought);
        Task DeleteBalancingAdjustmentYearBoughtAsync(BalancingAdjustmentYearBought balancingAdjustmentYearBought);
        Task<BalancingAdjustmentYearBought> GetBalancingAdjustmentYearBoughtById(int Id);

        Task<BalancingAdjustment> GetBalancingAdjustmentById(int balancingAdjustmentId);
    }
    
}