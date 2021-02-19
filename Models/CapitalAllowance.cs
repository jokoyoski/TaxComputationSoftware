using System;
namespace TaxComputationAPI.Models
{
    public class CapitalAllowance
    {

        public int Id {get;set;}
        public string TaxYear { get; set; }
        public decimal  OpeningResidue { get; set; }
        public decimal Addition { get; set; }
        public decimal Disposal { get; set; }
        public decimal Initial { get; set; }
        public decimal Annual { get; set; }
        public decimal Total { get;set;}
        public decimal ClosingResidue { get; set; }
        public int YearsToGo { get; set; }
        public int CompanyId { get; set; }
        public int AssetId { get; set; }
        public string YearId {get;set;}

        public int NumberOfYearsAvailable {get;set;}
        public string CompanyCode {get;set;}
        
        public  string Year { get; set; }

        public string  Channel {get;set;} 

    }
}
