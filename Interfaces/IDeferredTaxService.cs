using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Interfaces
{
    public interface IDeferredTaxService
    {
        Task SaveDeferredTax(CreateDeferredTax deferredTax);

        Task<DeferredTaxFoward> GetBroughtFoward(int companyId);
        Task<List<DeferredTaxDto>> GetDeferredTax(int companyId, int yearId, bool IsBringDeferredTaxFoward);
    }
}