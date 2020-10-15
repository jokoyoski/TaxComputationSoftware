using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Services
{
    public class TrialBalanceService : ITrialBalanceService
    {
        private readonly ITrialBalanceRepository _trialBalancerepository;
        public TrialBalanceService(ITrialBalanceRepository trialBalanceRepository){
         _trialBalancerepository=trialBalanceRepository;
        }
        public  async Task UpdateTrialBalance(int trialBalanceId,string mappedTo)
        {
            _trialBalancerepository.UpdateTrialBalance(trialBalanceId,mappedTo);
        }
    }
}