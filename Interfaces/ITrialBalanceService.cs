using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface ITrialBalanceService
    {
        Task UpdateTrialBalance (int trialBalanceId,string mappedTo);


        Task<List<TrialBalance>> GetTrialBalance(int companyId, int yearId);

        Task UploadTrialBalance(UploadTrackTrialBalanceDto excel);


    }
}