namespace TaxComputationSoftware.Models
{
    public class AsessableLossUnRelieved
    {
        public decimal AssessableLoss { get; set; }

        public decimal UnRelievedCf { get; set; }

        public int YearId { get; set; }

        public int CompanyId { get; set; }
    }
}