using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Models;
using TaxComputationSoftware.Respoonse;

namespace TaxComputationAPI.Interfaces
{
    public interface IMinimumTaxService
    {
        Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYear(int companyId, int yearId);
        Task<MinimumTaxResponse> AddOldMinimumTax(AddMinimumTaxDto addMinimumTaxDto);
        Task<MinimumTaxResponse> GetOldMinimumTax(int companyId, int financialYearId);
        
    }
}
