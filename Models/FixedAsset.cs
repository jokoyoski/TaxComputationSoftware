namespace TaxComputationAPI.Models
{
    public class FixedAsset
    {
        public int Id {get;set;}
        public int CompanyId {get;set;} 
        public int YearId {get;set;}
        public int AssetId {get;set;}
        public long OpeningCost {get;set;}

        public long TransferCost {get;set;}

        public long CostAddition {get;set;}

        public long CostDisposal {get;set;}


      ///   public long CostClosing {get;set;}

        public bool IsTransferCostRemoved {get;set;}
        
       
         public long OpeningDepreciation {get;set;}

         public long TransferDepreciation {get;set;}
        
        public long DepreciationAddition {get;set;}

        public long DepreciationDisposal {get;set;}

     ///   public long DepreciationClosing {get;set;}

       public bool IsTransferDepreciationRemoved {get;set;}
        

    }
}