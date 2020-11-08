
using System.Collections.Generic;
using TaxComputationAPI.Helpers.Response;

namespace TaxComputationAPI.Response
{

    public class AddBalancingAdjustmentResponse : Response<BalancingAdjustmentDisplay>
    {
    }


    public class BalancingAdjustmentDisplay
    {
        public string Company { get; set; }
        public string BalancingAdjustmentYear { get; set; }
        public List<BalancingAdjustment> BalancingAdjustments { get; set; }
    }

    public class BalancingAdjustment
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }

        public List<YearBoughtAdjustment> AssetYear { get; set ;}
    }

    public class YearBoughtAdjustment
    {
        public decimal Cost { get; set; }
        public decimal InitialAllowance { get; set;}
        public decimal AnnualAllowance { get; set; }
        public decimal BalancingCharge { get; set; }
        public decimal BalancingAllowance { get; set; }
        public decimal SalesProceed { get; set; }
        public string CostStatement { get; set; }
        public string YearBought { get; set;}
        public decimal Residue { get; set; }

        public YearBoughtAdjustment()
        {
            CostStatement = $"Cost up to {Cost} YOA";
        }
    }
    
}