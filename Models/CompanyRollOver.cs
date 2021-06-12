using System;

namespace TaxComputationSoftware.Models
{
    public class CompanyRollOver
    {
        public int CompanyId {get;set;}
        public string CompanyName {get;set;}
        public string TinNumber {get;set;}
        public DateTime ClosingDate {get;set;}
    }
}