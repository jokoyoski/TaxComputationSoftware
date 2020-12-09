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

        public async Task<InvestmentAllowance> GetInvestmentAllowanceByAssetIdAndYearId(int assetId, int year)
        {
            var record = await _investmentAllowanceRepository.GetInvestmentAllowanceByAssetIdAndYearId(assetId, year);
            return record;
        }
    }
}
