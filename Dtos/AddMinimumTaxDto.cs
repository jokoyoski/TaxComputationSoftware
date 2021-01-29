

namespace TaxComputationSoftware.Dtos
{
    public class AddMinimumTaxDto
    {
        public int CompanyId { get; set; }
        public int FinancialYearId { get; set; }
        public decimal GrossProft { get; set; }
        public decimal NetAsset { get; set; }
        public decimal ShareCapital { get; set; }
        public int TurnOver { get; set; } = 500000;

    }
}