using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IBalancingAdjService
    {
        Task<BalancingAdjustment> GetBalancingAdjAsync(int AssetId);
        Task AddBalancingAdjAsync(BalancingAdjustment adjustment);
    }
}
