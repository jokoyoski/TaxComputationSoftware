using System.Threading.Tasks;

namespace TaxComputationSoftware.Interfaces
{
    public interface IAnnualService
    {
        Task UnlockCapitalAllowance(int companyId);
    }
}