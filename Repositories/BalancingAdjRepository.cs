using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Repositories
{
    public class BalancingAdjRepository : IBalancingAdjRepository
    {
        private readonly DataContext _context;
        public BalancingAdjRepository(DataContext context)
        {
            _context = context;

        }
    }
}
