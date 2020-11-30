using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Interfaces
{
    public interface IMinimumTaxService
    {
        Task<decimal> GetMinimumTaxByCompanyIdAndYear(int companyId, int yearId);
    }
}
