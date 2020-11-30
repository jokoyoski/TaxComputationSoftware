using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IITLevyRepository
    {
        Task<ITLevy> GetITLevyByCompanyIdAndYearId(int companyId, int yearId);
    }
}
