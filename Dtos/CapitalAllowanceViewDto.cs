namespace TaxComputationSoftware.Dtos
{
    public class CapitalAllowanceViewDto
    {
        public string TaxYear { get; set; }
        public string OpeningResidue { get; set; }
        public int Id {get;set;}
        public int NumberOfYearsAvailable {get;set;}
        public string Addition { get; set; }
        public string Disposal { get; set; }
        public string Initial { get; set; }
        public string Annual { get; set; }
        public string Total { get; set; }
        public string ClosingResidue { get; set; }
        public int YearsToGo { get; set; }
       
    }
}