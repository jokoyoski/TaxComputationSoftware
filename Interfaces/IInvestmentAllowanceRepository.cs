using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IInvestmentAllowanceRepository
    {
        Task AddInvestmentAllowanceAsync(InvestmentAllowance investmentAllowance);
        Task DeleteInvestmentAllowanceAsync(int Id);
        Task<List<InvestmentAllowance>> GetInvestmentAlowanceByCompanyIdYearId(int companyId, int yearId);
    }
}
