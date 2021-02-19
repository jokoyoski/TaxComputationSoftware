using System.Collections.Generic;

namespace TaxComputationSoftware.Dtos
{
    public class InvestmentAllowanceListDto
    {

        public List<Investment> Investments {get;set;}

        public string InvestmentAllowanceatTenPercent {get;set;}
       

    }



    public class Investment{
       
        public int Id {get;set;}
         public string Name {get;set;}

        public string Amount  {get;set;}
    }
}