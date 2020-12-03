using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class ITLevyRepository : IITLevyRepository
    {
        public async Task<ITLevyViewDto> GetITLevyByCompanyIdAndYearId(int companyId, int yearId)
        {
           
            return new ITLevyViewDto { ProfitBeforeTaxation="30000.30", ITLevyAt1PercentThereIn="300.23"};
        }
    }
}
