using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;

namespace TaxComputationAPI.Interfaces
{
    public interface IInvestmentAllowanceService
    {
        Task AddInvestmentAllowanceAsync(InvestmentAllowance investment);
        Task DeleteInvestmentAllowanceAsync(int Id);
        Task<InvestmentAllowanceListDto> GetInvestmentAllowances(int companyId, int yearId);
    }
}
