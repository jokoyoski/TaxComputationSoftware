using System.Threading.Tasks;

namespace TaxComputationAPI.Interfaces
{
    public interface ITrialBalanceService
    {
        Task UpdateTrialBalance ( int trialBalanceId,string mappedTo);


    }
}