using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class BalancingAdjustment
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int Cost { get; set; }
        public int InitialAllowance { get; set; }
        public int AnnualAllowance { get; set; }
        public int CompanyId { get; set; }
        public int Residue { get; set; }
        public int SalesProceed { get; set; }
        public int BalancingCharge { get; set; }
        public int BalancingAllowance { get; set; }
    }
}
