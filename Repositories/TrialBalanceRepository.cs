using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;
using System.Linq;

namespace TaxComputationAPI.Repositories
{
    public class TrialBalanceRepository : ITrialBalanceRepository
    {
        private readonly DataContext _dataContext;
        public TrialBalanceRepository(DataContext dataContext){
          _dataContext=dataContext;
        }
        public  async Task UpdateTrialBalance(int trialBalanceId,string mappedTo)
        {
            var record= _dataContext.TrialBalance.FirstOrDefault(x=>x.Id==trialBalanceId);
           if(record!=null)
           {
           record.IsCheck=true;
           record.MappedTo=mappedTo;
           _dataContext.SaveChanges();
        
           }

        }
    }
}