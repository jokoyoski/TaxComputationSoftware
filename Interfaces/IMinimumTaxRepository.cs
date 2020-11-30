using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
     public interface IMinimumTaxRepository
    {
        Task<MinimumTax> GetMinimumTaxByCompanyIdAndYearId(int companyId, int yearId);
    }
}
