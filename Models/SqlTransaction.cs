using System;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class SqlTransaction : ISqlTransactionDao<string>
    {
        public string GetValue()
        {
            throw new NotImplementedException();
        }

        public Task SaveCapitalAllowance(CapitalAllowance capitalAllowance)
        {
            throw new NotImplementedException();
        }
    }

    public class SqlObject<IdT>
    {
        public virtual IdT Id { get; set; }
    }
}
