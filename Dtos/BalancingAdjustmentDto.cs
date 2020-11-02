using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class BalancingAdjustmentDto
    {
        public int AssetId { get; set; }
        public int Cost { get; set; }
        public int SalesProceed { get; set; }
        public int CompanyId { get; set; }
        public int Year { get; set; }

    }
}
