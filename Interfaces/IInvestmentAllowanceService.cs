using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IInvestmentAllowanceService
    {
        Task AddInvestmentAllowanceAsync(InvestmentAllowance investment);
        Task DeleteInvestmentAllowanceAsync(InvestmentAllowance investment);
    }
}
