using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Services
{
    public class ITLevyService : IITLevyService
    {
        private readonly IITLevyRepository _iTLevyRepository;

        public ITLevyService(IITLevyRepository iTLevyRepository) => _iTLevyRepository = iTLevyRepository;
        public async Task<ITLevyViewDto> GetITLevyByCompanyIdAndYear(int companyId, int yearId)
        {
            var record = await _iTLevyRepository.GetITLevyByCompanyIdAndYearId(companyId, yearId);
            return record;
        }
    }
}
