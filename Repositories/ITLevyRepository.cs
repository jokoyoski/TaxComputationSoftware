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
            try
            {
                return new ITLevyViewDto { CompanyId = 1, YearId = 2020, turnOver = 10,  fivePercentTurnOver = 10 };
            }
            catch (Exception ex)
            {

            }

            return new ITLevyViewDto { CompanyId = 1, YearId = 2020, turnOver = 10, fivePercentTurnOver = 10 };
        }
    }
}
