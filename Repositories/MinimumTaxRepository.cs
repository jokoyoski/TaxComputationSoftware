using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class MinimumTaxRepository : IMinimumTaxRepository
    {
        public async Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYearId(int companyId, int yearId)
        {
          

            return new MinimumTaxViewDto { turnOver="220.23", fivePercentTurnOver ="3000.30"};
        }
    }
}
