using System.Collections.Generic;

namespace TaxComputationSoftware.Dtos
{
    public class CapitalAllowanceSummaryDto
    {
       public string Description {get;set;}

       public string OpeningResidue{get;set;}

       public string Addition {get;set;}

       public string DisposalOrTransfer {get;set;}

       public string Initial {get;set;}

       public string Annual {get;set;}

       public string Total {get;set;}

       public string ClosingResidue {get;set;}

       public int AssetId {get;set;}

       public int CompanyId {get;set;}
    }



   
}