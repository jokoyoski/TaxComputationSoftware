using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;

namespace TaxComputationAPI.Interfaces
{
    public interface IITLevyService
    {
        Task<ITLevyViewDto> GetITLevyByCompanyIdAndYear(int companyId, int yearId);
    }
}
