using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class ITLevyRepository : IITLevyRepository
    {
        public async Task<ITLevy> GetITLevyByCompanyIdAndYearId(int companyId, int yearId)
        {
            try
            {
                
            }
            catch (Exception ex)
            {


            }

            return null;
        }
    }
}
