using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class MinimumTaxViewDto
    {
        public string turnOver { get; set; }

        public string fivePercentTurnOver { get; set; }
    }
}
