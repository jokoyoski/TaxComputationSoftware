namespace TaxComputationSoftware.Models
{
    public class AddProfitAndLoss
    {
        public int YearId {get;set;}

        public int CompanyId {get;set;}

        public string Type {get;set;}


        public decimal Amount {get;set;}
    }
}