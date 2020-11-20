using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
   public interface ITrialBalanceRepository
    {
        Task UpdateTrialBalance(int trialBalanceId,string mappedTo, bool isDelete);

        Task<TrackTrialBalance> GetTrackTrialBalance(int companyId, int yearId);

        Task<List<TrialBalance>> GetTrialBalance(int trackId);

        Task<TrackTrialBalance> AddTrackTrialBalance(TrackTrialBalance model);

        Task<TrialBalance> UploadTrialBalance(TrialBalance model);

        Task<TrialBalance> RemoveTrackTrialBalance(TrialBalance trialBalance);
      
    }
}