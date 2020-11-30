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
        public async Task<decimal> GetITLevyByCompanyIdAndYear(int companyId, int yearId)
        {


            decimal turnover = 0;
            decimal fivePercentTurnover = turnover * 5 / 100;

            return fivePercentTurnover;
        }
    }
}
