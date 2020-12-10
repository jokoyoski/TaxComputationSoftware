using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services
{
    public class InvestmentAllowanceService : IInvestmentAllowanceService
    {
        private readonly IUtilitiesService _utilitiesService;
        private readonly IFixedAssetService _fixedAssetService;
        private readonly IInvestmentAllowanceRepository _investmentAllowanceRepository;
        public InvestmentAllowanceService(IUtilitiesService utilitiesService, IFixedAssetService fixedAssetService, IInvestmentAllowanceRepository investmentAllowanceRepository)
        {
            _utilitiesService = utilitiesService;
            _fixedAssetService = fixedAssetService;
            _investmentAllowanceRepository = investmentAllowanceRepository;

        }

        public async Task AddInvestmentAllowanceAsync(InvestmentAllowance investmentAllowance)
        {
            if (investmentAllowance == null)
            {
                throw new ArgumentNullException(nameof(investmentAllowance));
            }


            await _investmentAllowanceRepository.AddInvestmentAllowanceAsync(investmentAllowance);
        }

        public async Task DeleteInvestmentAllowanceAsync(InvestmentAllowance investmentAllowance)
        {
            if (investmentAllowance == null)
            {
                throw new ArgumentNullException(nameof(investmentAllowance));
            }

            await _investmentAllowanceRepository.DeleteInvestmentAllowanceAsync(investmentAllowance);
        }
    }
}
