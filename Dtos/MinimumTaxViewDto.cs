using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class MinimumTaxViewDto
    {
        public string Item { get; set; }
        public int CompanyId { get; set; }
        public int YearId { get; set; }

        public decimal turnOver { get; set; }

        public decimal fivePercentTurnOver { get; set; }
    }
}
