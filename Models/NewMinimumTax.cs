namespace TaxComputationSoftware.Models
{
    public class NewMinimumTax
    {
        public decimal OtherOperatingIncome {get;set;}
         public decimal OtherOperatingGain {get;set;}
         public decimal Revenue {get;set;}
         public int CompanyId {get;set;}
         public int YearId {get;set;}
    }
}