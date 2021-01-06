namespace TaxComputationSoftware.Models
{
    public class BroughtFoward
    {
        public int Id { get; set; }

        public int YearId { get; set; }
        public int CompanyId { get; set; }
        public decimal LossCf { get; set; }
        public decimal UnRelievedCf { get; set; }

    }
}