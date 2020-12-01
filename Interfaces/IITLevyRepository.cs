using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IITLevyRepository
    {
        Task<ITLevyViewDto> GetITLevyByCompanyIdAndYearId(int companyId, int yearId);
    }
}
