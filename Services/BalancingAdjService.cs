using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Services
{
    public class BalancingAdjService : IBalancingAdjService
    {
        private readonly IBalancingAdjRepository _balancingAdjRepository;
        public BalancingAdjService(IBalancingAdjRepository balancingAdjRepository)
        {
            _balancingAdjRepository = balancingAdjRepository;

        }

    }
}
