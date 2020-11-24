using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationSoftware.Dtos;

namespace TaxComputationAPI.Interfaces
{
    public interface IProfitAndLossService
    {

       Task<List<ProfitAndLossViewDto>> GetProfitAndLossByCompanyIdAndYear(int companyId, int yearId);
        Task SaveProfitAndLoss(CreateProfitAndLoss createProfitAndLoss);
    }
}
 