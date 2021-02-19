using System;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public interface ISqlTransactionDao<T>
    {
        Task SaveCapitalAllowance(CapitalAllowance capitalAllowance);

        public T GetValue();
    }
}
