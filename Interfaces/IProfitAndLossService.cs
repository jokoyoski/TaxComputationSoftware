using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IProfitAndLossService
    {
        Task<decimal> GetProfitAndLossForIncomeTax(int companyId, int yearId);
        Task<bool> ValidateProfitAndLossInput(List<TrialBalanceValue> trialBalanceList, int companyId, int yearId, int profitAndLossId);

        Task<List<ProfitAndLossViewDto>> GetProfitAndLossByCompanyIdAndYear(int companyId, int yearId);
        Task SaveProfitAndLoss(CreateProfitAndLoss createProfitAndLoss);
        Task<NewMinimumTax> GetNewMinimumTax(int companyId, int yearId);

        Task SaveProfitsAndLoss(CreateProfitAndLoss profits);

        Task<string> GetITLevy(int companyId, int yearId);
    }
}
