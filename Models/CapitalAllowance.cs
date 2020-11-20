using System;
namespace TaxComputationAPI.Models
{
    public class CapitalAllowance
    {
        public string TaxYear { get; set; }
        public string OpeningResidue { get; set; }
        public string Addition { get; set; }
        public string Disposal { get; set; }
        public string Initial { get; set; }
        public string Annual { get; set; }
        public string Total { get;set;}
        public string ClosingResidue { get; set; }
        public string YearsToGo { get; set; }
        public int CompanyId { get; set; }
        public int AssetId { get; set; }

    }
}
