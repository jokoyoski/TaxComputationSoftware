using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Model;

namespace TaxComputationAPI.Interfaces
{
     public interface IMinimumTaxRepository
    {
        Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYearId(int companyId, int yearId);

        Task<MinimumTaxModel> GetMinimumCompanyIdYearId(int companyId, int yearId);
    
        Task<MinimumTaxModel> SaveMinimum(MinimumTaxModel minimumTaxDto);
    
    }
}
