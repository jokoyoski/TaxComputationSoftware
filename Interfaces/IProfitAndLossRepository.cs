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
        Task<List<TaxComputationSoftware.Models.ProfitsAndLoss>> GetProfitsAndLossByType(string Type);
        Task DeleteProfitsAndLossById(int TrialBalanceId);
        Task CreateProfitsAndLoss(TaxComputationSoftware.Dtos.ProfitsAndLoss profits);
        Task<TaxComputationSoftware.Models.ProfitsAndLossValue> GetProfitsAndlossByTrialBalanceId(int TrialBalanceId,int yeardId);
           
    }
}
