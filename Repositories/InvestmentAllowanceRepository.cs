using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class InvestmentAllowanceRepository : IInvestmentAllowanceRepository
    {
        public async Task<InvestmentAllowance> GetInvestmentAllowanceByAssetIdAndYearId(int assetId, int year)
        {
            try
            {
                return new InvestmentAllowance { AssetId = 1, YearId = 2020 };
            }
            catch (Exception ex)
            {

            }

            return new InvestmentAllowance { AssetId = 1, YearId = 2020 };
        }
    }
}
