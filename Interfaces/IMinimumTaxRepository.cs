using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Model;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IMinimumTaxRepository
    {
        Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYearId(int companyId, int yearId);

        Task<MinimumTaxModel> GetMinimumCompanyIdYearId(int companyId, int yearId);
    
        Task<MinimumTaxModel> SaveMinimum(MinimumTaxModel minimumTaxDto);
        Task<MinimumTaxModel> UpdatedMinimum(MinimumTaxModel minimumTaxDto);
        

        Task<MinimumTaxPercentageValue> GetMinimumTaxPercentageCompanyIdYearId(int companyId, int yearId);
        Task<MinimumTaxPercentageValue> SaveMinimumPercentage(MinimumTaxPercentageValue minimumTaxDto);


    }
}
