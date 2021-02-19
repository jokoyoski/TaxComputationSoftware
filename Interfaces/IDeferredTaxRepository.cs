using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Interfaces
{
    public interface IDeferredTaxRepository
    {
        Task DeleteFairGainByTrialBalanceId(int Id);

        Task<IEnumerable<FairValueGain>> GetFairValueGainByCompanyIdAndYear(int companyId, int year);

        Task<int> CreateFairValueGain(FairValueGain fairValueGain);

        Task<int> UpdateDeferredTaxfById(int companyId);  //background job
        Task<int> UpdateDeferredTaxBroughtFowardByDeferredTax(int companyId, decimal broughtFoward);
        Task<int> CreateDeferredTaxBroughtFoward(int companyId, decimal deferredTaxBroughtFoward,int yearId);
        Task<IEnumerable<DeferredTaxFoward>> GetDeferredTaxFowarByCompanyId(int companyId);
    }
}