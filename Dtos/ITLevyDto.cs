using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class ITLevyDto
    {
        public int CompanyId { get; set; }
        public int YearId { get; set; }
        public decimal turnover { get; set; }
        public decimal fivePercentTurnover { get; set; }
    }
}
