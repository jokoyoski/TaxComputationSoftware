using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface ICapitalAllowanceService
    {
        Task<int> SaveCapitalAllowance(CapitalAllowance capitalAllowance);

        Task<IEnumerable<CapitalAllowance>> GetCapitalAllowance(int assetId, int companyId);
    }
}
