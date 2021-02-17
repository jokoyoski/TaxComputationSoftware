namespace TaxComputationSoftware.Models
{
    public class ProfitsAndLoss
    {
        public int TrialBalanceId { get; set; }
        public string Pick { get; set; }

        public string TypeValue { get; set; }
        public string YearId { get; set; }
    }


    public class ProfitsAndLossValue
    {
        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public string Pick { get; set; }

        
    }
}