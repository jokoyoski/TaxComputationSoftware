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

         public int Year {get;set;}
        public string FixedAssetName {get;set;}    
        public long OpeningCost {get;set;}
        
         public long TransferCost {get;set;}

        public long TransferDepreciation {get;set;}

        public bool IsTransferCostRemoved {get;set;}

         public bool IsTransferDepreciationRemoved {get;set;}
        public long CostAddition {get;set;}

        public long CostDisposal {get;set;}

        public long CostClosing {get;set;}

         public long OpeningDepreciation {get;set;}
        
        public long DepreciationAddition {get;set;}

        public long DepreciationDisposal {get;set;}

        public long DepreciationClosing {get;set;}

       }




   public class Total {

    public long OpeningCostTotal  {get;set;}

    public long AdditionCostTotal {get;set;}

    public long DisposalCostTotal {get;set;}

    public long ClosingCostTotal {get;set;}

    public long OpeningDepreciationTotal  {get;set;}

    public long AdditionDepreciationTotal {get;set;}

    public long DisposalDepreciationTotal {get;set;}

     public long ClosingDepreciationTotal {get;set;}
    }

   public class NetBookValue{

       public long value {get;set;}
   }

}