using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
 using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;
using TrialBalance = TaxComputationAPI.Models.TrialBalance;

namespace TaxComputationAPI.Interfaces
{
    public interface ITrialBalanceService
    {
        Task UpdateTrialBalance (int trialBalanceId,string mappedTo,bool isDelete);


        Task<List<TrialBalance>> GetTrialBalance(int companyId, int yearId);

        Task UploadTrialBalance(UploadTrackTrialBalanceDto excel);


    }
}