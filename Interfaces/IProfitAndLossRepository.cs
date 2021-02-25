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
        Task UpdateProfitAndLoss(AddProfitAndLoss addProfitAndLoss);
        Task<List<TaxComputationSoftware.Models.ProfitsAndLossValue>> GetProfitsAndLossByType(string Type, int companyId, int yearId);
        Task DeleteProfitsAndLossById(int TrialBalanceId);
        Task CreateProfitsAndLoss(TaxComputationSoftware.Dtos.ProfitsAndLoss profits);
        Task<TaxComputationSoftware.Models.ProfitsAndLossValue> GetProfitsAndlossByTrialBalanceId(int TrialBalanceId, int yeardId);
        Task<string> SaveProfitAndLossRecord(ProfitAndLossRecord profitAndLoss);
        Task<ProfitAndLossRecord> GetProfitAndLossRecordAsync(int companyId, int yearId);


    }
}
