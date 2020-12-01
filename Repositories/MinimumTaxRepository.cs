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
            try
            {
                return new MinimumTaxViewDto { CompanyId = 1, YearId = 2020, turnOver = 10, fivePercentTurnOver = 10 };
            }
            catch (Exception ex)
            {
                
            }

            return new MinimumTaxViewDto { CompanyId = 1, YearId = 2020, turnOver = 10, fivePercentTurnOver = 10 };
        }
    }
}
