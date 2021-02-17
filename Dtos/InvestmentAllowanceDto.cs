using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class InvestmentAllowanceDto
    {
        public int AssetId { get; set; }
        public int CompanyId { get; set; }
        public int YearId { get; set; }
    }
}
