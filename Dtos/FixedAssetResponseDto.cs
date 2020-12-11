using System.Collections.Generic;

namespace TaxComputationAPI.Dtos
{
    public class FixedAssetResponseDto
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
        public string OpeningCost {get;set;}
        
         public string TransferCost {get;set;}

        public string TransferDepreciation {get;set;}

         public string CostAddition {get;set;}

        public string CostDisposal {get;set;}

        public string CostClosing {get;set;}

         public string OpeningDepreciation {get;set;}
        
        public string DepreciationAddition {get;set;}

        public string DepreciationDisposal {get;set;}

        public string DepreciationClosing {get;set;}

       }




   public class Total {

    public string OpeningCostTotal  {get;set;}

    public string AdditionCostTotal {get;set;}

    public string DisposalCostTotal {get;set;}

    public string ClosingCostTotal {get;set;}

    public string OpeningDepreciationTotal  {get;set;}

    public string AdditionDepreciationTotal {get;set;}

    public string DisposalDepreciationTotal {get;set;}

     public string ClosingDepreciationTotal {get;set;}

     public string TransferCostTotal    {get;set;}

     public string TransferDepreciationTotal {get;set;}
    }

   public class NetBookValue{

       public string value {get;set;}
   }
    }
