namespace TaxComputationSoftware.Dtos
{
    public class ProfitsAndLoss
    {
        public int TrialBalanceId { get; set; }
        public string Pick { get; set; }

        public int Year { get; set; }

        public int CompanyId {get;set;}

        public string TypeValue {get;set;}
    }
}