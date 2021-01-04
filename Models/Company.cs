using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CacNumber { get; set; }
        public string TinNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime OpeningYear { get; set; }
        public DateTime ClosingYear { get; set; }
        public bool IsActive { get; set; }
        public int MonthOfOperation {get;set;}
    }
}
