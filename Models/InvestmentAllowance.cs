using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class InvestmentAllowance
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int YearId { get; set; }
    }
}
