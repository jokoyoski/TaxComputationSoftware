using System.Collections.Generic;

namespace TaxComputationAPI.ResponseModel
{
    public class FixedAssetResponse
    {
       public List<FixedAssetData> FixedAssetData {get;set;}
       public Total total {get;set;}

       public  List<NetBookValue> netBookValue {get;set;}

    }
    

    public class  FixedAssetData{
        public int Id {get;set;}   
         public  string CompanyName  {get;set;}
         public int AssetId {get;set;}
         public string Year {get;set;}
         public string YearName {get;set;}
        public string FixedAssetName {get;set;}    
        public decimal OpeningCost {get;set;}
        
         public decimal TransferCost {get;set;}

        public decimal TransferDepreciation {get;set;}

        public bool IsTransferCostRemoved {get;set;}

         public bool IsTransferDepreciationRemoved {get;set;}
        public decimal CostAddition {get;set;}

        public decimal CostDisposal {get;set;}

        public decimal CostClosing {get;set;}

         public decimal OpeningDepreciation {get;set;}
        
        public decimal DepreciationAddition {get;set;}

        public decimal DepreciationDisposal {get;set;}

        public decimal DepreciationClosing {get;set;}

       }




   public class Total {

    public decimal OpeningCostTotal  {get;set;}

    public decimal AdditionCostTotal {get;set;}

    public decimal DisposalCostTotal {get;set;}

    public decimal ClosingCostTotal {get;set;}

    public decimal OpeningDepreciationTotal  {get;set;}

    public decimal AdditionDepreciationTotal {get;set;}

    public decimal DisposalDepreciationTotal {get;set;}

     public decimal ClosingDepreciationTotal {get;set;}
    }

   public class NetBookValue{

       public decimal value {get;set;}
   }

}