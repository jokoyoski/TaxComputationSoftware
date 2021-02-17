namespace TaxComputationAPI.Models
{
    public class FixedAsset
    {
        public int Id {get;set;}
        public int CompanyId {get;set;} 
        public int YearId {get;set;}
        public int AssetId {get;set;}
        public decimal OpeningCost {get;set;}

        public decimal TransferCost {get;set;}

        public decimal CostAddition {get;set;}

        public decimal CostDisposal {get;set;}


      ///   public long CostClosing {get;set;}

        public bool IsTransferCostRemoved {get;set;}
        
       
         public decimal OpeningDepreciation {get;set;}

         public decimal TransferDepreciation {get;set;}
        
        public decimal DepreciationAddition {get;set;}

        public decimal DepreciationDisposal {get;set;}

     ///   public long DepreciationClosing {get;set;}

       public bool IsTransferDepreciationRemoved {get;set;}
        

    }
}