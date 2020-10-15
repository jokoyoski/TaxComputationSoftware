using System.Threading.Tasks;

namespace TaxComputationAPI.Interfaces
{
   public interface ITrialBalanceRepository
    {
        Task UpdateTrialBalance(int trialBalanceId,string mappedTo);
      
    }
}