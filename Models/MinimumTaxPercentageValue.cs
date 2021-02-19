namespace TaxComputationSoftware.Models
{
    public class MinimumTaxPercentageValue
    {
        public int YearId {get;set;}

        public int CompanyId {get;set;}

        public decimal MinimumTaxPercentage {get;set;}
    }
}