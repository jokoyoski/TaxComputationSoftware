using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services
{
    public class UtilitiesService : IUtilitiesService
    {
        private readonly IUtilitiesRepository _utilitiesRepository;
        public UtilitiesService(IUtilitiesRepository utilitiesRepository)
        {
            _utilitiesRepository = utilitiesRepository;

        }

        public async Task<AssetClass> GetAssetClassAsync(string name)
        {
            return await _utilitiesRepository.GetAssetClassAsync(name);
        }

        public async Task AddAssetClassAsync(AssetClass assetClass)
        {
            if (assetClass == null)
            {
                throw new ArgumentNullException(nameof(assetClass));
            }


            await _utilitiesRepository.AddAssetClassAsync(assetClass);
        }

        public async Task<FinancialYear> GetFinancialYearAsync(string name)
        {
            return await _utilitiesRepository.GetFinancialYearAsync(name);
        }

        public async Task AddFinancialYearAsync(FinancialYear financialYear)
        {
            if (financialYear == null)
            {
                throw new ArgumentNullException(nameof(financialYear));
            }


            await _utilitiesRepository.AddFinancialYearAsync(financialYear);
        }
    }
}
