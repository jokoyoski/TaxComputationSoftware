using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services
{
    public class CapitalAllowanceService : ICapitalAllowanceService
    {
        private readonly ICapitalAllowanceRepository _capitalAllowanceRepository;

        public CapitalAllowanceService(ICapitalAllowanceRepository capitalAllowanceRepository)
        {
            _capitalAllowanceRepository = capitalAllowanceRepository;
        }

        public Task<IEnumerable<CapitalAllowance>> GetCapitalAllowance(int assetId, int companyId)
        {
            return _capitalAllowanceRepository.GetCapitalAllowance(assetId, companyId);
        }

        public Task<int> SaveCapitalAllowance(CapitalAllowance capitalAllowance)
        {
            return _capitalAllowanceRepository.SaveCapitaLAllowance(capitalAllowance);

        }
    }
}
