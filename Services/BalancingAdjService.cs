using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services
{
    public class BalancingAdjService : IBalancingAdjService
    {
        private readonly IBalancingAdjRepository _balancingAdjRepository;
        public BalancingAdjService(IBalancingAdjRepository balancingAdjRepository)
        {
            _balancingAdjRepository = balancingAdjRepository;

        }

        public async Task<BalancingAdjustment> GetBalancingAdjAsync(int AssetId)
        {
            return await _balancingAdjRepository.GetBalancingAdjAsync(AssetId);
        }

        public async Task AddBalancingAdjAsync(BalancingAdjustment adjustment)
        {
            if (adjustment == null)
            {
                throw new ArgumentNullException(nameof(adjustment));
            }

            await _balancingAdjRepository.AddBalancingAdjAsync(adjustment);
        }

    }
}
