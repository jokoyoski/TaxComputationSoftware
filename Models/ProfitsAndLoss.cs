namespace TaxComputationSoftware.Models
{
    public class ProfitsAndLoss
    {
        public int TrialBalanceId { get; set; }
        public string Pick { get; set; }

        public string TypeValue {get;set;}
        public string YearId { get; set; }
    }


    public class ProfitsAndLossValue{
        public decimal Value {get;set;}
    }
}