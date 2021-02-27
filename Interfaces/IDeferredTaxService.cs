using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Interfaces
{
    public interface IDeferredTaxService
    {
        Task<List<DeferredTaxDto>> GetDeferredTax(int companyId, int yearId, bool IsBringDeferredTaxFoward);
    }
}