using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IProfitAndLossRepository
    {

        Task<ProfitAndLoss> GetProfitAndLossByCompanyIdAndYearId(int companyId,int yearId);
        Task UpdateProfitAndLoss(AddProfitAndLoss addProfitAndLoss);
    }
}
