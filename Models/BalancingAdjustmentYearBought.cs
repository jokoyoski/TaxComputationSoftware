

using System;

namespace TaxComputationAPI.Models
{
    public class BalancingAdjustmentYearBought
    {
        public int Id { get; set; }
        public int AssestId { get; set; }
        public decimal Cost { get; set; }
        public decimal InitialAllowance { get; set; }
        public decimal AnnualAllowance { get; set; }
        public decimal SalesProceed { get; set; }
        public decimal Residue { get; set; }
        public decimal BalancingAllowance { get; set; }
        public decimal BalancingCharge { get; set; }
        public DateTime DateCreated { get; set; }
        public string YearBought { get; set; }
        public int BalancingAdjustmentId { get; set; }

    }
}