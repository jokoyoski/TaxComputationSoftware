using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Services
{
    public class MinimumTaxService : IMinimumTaxService
    {
        public async Task<decimal> GetMinimumTaxByCompanyIdAndYear(int companyId, int yearId)
        {


            decimal turnover = 0;
            decimal onePercentTurnover = turnover * 1 / 100;

            return onePercentTurnover;
        }
    }
}
