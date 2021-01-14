namespace TaxComputationSoftware.Models
{
    public class FairValueGain
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int YearId { get; set; }

        public int TrialBalanceId { get; set; }

        public int SelectionId { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public string Item { get; set; }
        public int DeferredFairValueGainId { get; set; }

    }
}