using System;

namespace TaxComputationSoftware.Models
{
    public class CompanyCode
    {
        public DateTime NextExecution {get;set;}
        public  string Code  {get;set;}

        public int CompanyId {get;set;}
    }
}