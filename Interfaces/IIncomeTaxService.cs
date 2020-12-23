using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Interfaces
{
    public interface IIncomeTaxService
    {
        Task SaveAllowableDisAllowable(CreateIncomeTaxDto incomeTax);

        Task<List<IncomeTaxDto>> GetIncomeTax(int companyId, int yearId);

        Task DeleteAllowableDisAllowable(int allowableDisAllowableId);
        Task<BroughtFoward> GetBroughtFoward(int companyId);
    }
}