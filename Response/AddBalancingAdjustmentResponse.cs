
using System.Collections.Generic;
using TaxComputationAPI.Helpers.Response;

namespace TaxComputation.Response
{

    public class AddBalancingAdjustmentResponse : Response<BalancingAdjustment>
    {
    }


    public class BalancingAdjustment
    {
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
        public string CostStatement { get; set; }

        public YearBoughtAdjustment()
        {
            CostStatement = $"Cost up to {Cost} YOA";
        }
    }
    
}