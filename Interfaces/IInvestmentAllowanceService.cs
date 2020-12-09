using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IInvestmentAllowanceService
    {
        Task<InvestmentAllowance> GetInvestmentAllowanceByAssetIdAndYearId(int assetId, int year);
    }
}
