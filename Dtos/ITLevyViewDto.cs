using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class ITLevyViewDto
    {
        public string ProfitBeforeTaxation { get; set; }
        public string ITLevyAt1PercentThereIn { get; set; }
    }
}
