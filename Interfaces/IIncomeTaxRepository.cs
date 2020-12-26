using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Interfaces
{
    public interface IIncomeTaxRepository
    {
        Task DeleteAllowableDisAllowableById(int Id);
        Task<IEnumerable<AllowableDisAllowable>> GetAllowableDisAllowableByCompanyIdYearId(int companyId, int year);
        Task<BroughtFoward> GetBroughtFowardByCompanyId(int companyId);
        Task<int> CreateAllowableDisAllowable(AllowableDisAllowable allowableDisAllowable);

        Task<IEnumerable<AllowableDisAllowable>> GetAllowableDisAllowableByCompanyIdYearIdAllowable(int companyId, int year, int allowable);
        Task<AllowableDisAllowable> GetAllowableDisAllowableById(int Id);
        Task<AllowableDisAllowable> GetAllowableDisAllowableByTrialBalanceId(int Id);
        Task<int> CreateBalanceBroughtFoward(BroughtFoward broughtFoward);
        Task<int> UpdateLossBfById(int companyId);
        Task<int> UpdateAcessibleByIncomeTax(BroughtFoward broughtFoward);



    }
}