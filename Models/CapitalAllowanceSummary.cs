namespace TaxComputationSoftware.Models
{
    public class CapitalAllowanceSummary
    {
        public int Id { get; set; }
        public string AssetName {get;set;}
        public decimal OpeningResidue { get; set; }
        public decimal Addition { get; set; }
        public decimal Disposal { get; set; }
        public decimal Initial { get; set; }
        public decimal Annual { get; set; }
        public decimal Total { get; set; }
        public decimal ClosingResidue { get; set; }
        public int CompanyId { get; set; }
        public int AssetId { get; set; }

       
    }
}