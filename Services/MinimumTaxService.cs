using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Services
{
    public class MinimumTaxService : IMinimumTaxService
    {

        private readonly IMinimumTaxRepository _minimumTaxRepository;

        public MinimumTaxService(IMinimumTaxRepository minimumTaxRepository) => _minimumTaxRepository = minimumTaxRepository;
        public async Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYear(int companyId, int yearId)
        {
            var record = await _minimumTaxRepository.GetMinimumTaxByCompanyIdAndYearId(companyId, yearId);
            return record;
        }
    }
}
