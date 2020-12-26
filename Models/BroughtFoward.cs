namespace TaxComputationSoftware.Models
{
    public class BroughtFoward
    {
        public int CompanyId { get; set; }

        public bool IsStarted { get; set; }

        public decimal LossBf { get; set; }

        public decimal LossCf { get; set; }

        public decimal Accessible {get;set;}

        public decimal UnRelievedBf { get; set; }

        public decimal UnRelievedCf { get; set; }
    }
}