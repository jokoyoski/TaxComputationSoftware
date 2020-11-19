using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class BalancingAdjRepository : IBalancingAdjRepository
    {
        private readonly DataContext _context;
        public BalancingAdjRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<BalancingAdjustment> GetBalancingAdjAsync(int AssetId)
        {
            var balancingAdjustment = _context.BalancingAdjustment.FirstOrDefault(x => x.AssetId == AssetId);
            return balancingAdjustment;
        }

        public async Task AddBalancingAdjAsync(BalancingAdjustment adjustment)
        {

            await _context.BalancingAdjustment.AddAsync(adjustment);
            await _context.SaveChangesAsync();
        }
    }
}
