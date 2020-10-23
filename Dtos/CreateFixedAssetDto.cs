using System.Collections.Generic;

namespace TaxComputationAPI.Dtos
{
    public class CreateFixedAssetDto
    {
        public  int CompanyId  {get;set;}

        public int YearId {get;set;}

        public string MappedCode {get;set;}

        public int AssetId {get;set;}

        public List<int> TriBalanceId {get;set;}

        public bool IsCost {get;set;}
    
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

    
}