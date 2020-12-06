using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
     public interface IMinimumTaxRepository
    {
        Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYearId(int companyId, int yearId);
    }
}
