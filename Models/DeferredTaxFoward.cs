namespace TaxComputationSoftware.Models
{
    public class DeferredTaxFoward
    {

        public int Id {get;set;}

        public int CompanyId {get;set;}

        public bool IsStarted {get;set;}

        public decimal DeferredTaxBroughtFoward {get;set;}
      
    }
}