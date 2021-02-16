using System;

namespace TaxComputationAPI.Models
{
    public class FinancialYear
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string FinancialDate { get; set; }
        public int CompanyId { get; set; }
    }
}