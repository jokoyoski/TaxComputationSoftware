using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class CompanyForRegisterDto
    {
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "You must specify description between 10 and 20 characters")]
        public string CompanyDescription { get; set; }
        [Required(ErrorMessage = "CacNumber is Required")]
        public string CacNumber { get; set; }
        [Required(ErrorMessage = "TinNumber is Required")]
        public string TinNumber { get; set; }

        public string ClosingYear { get; set; }
        [Required(ErrorMessage = "OpeningYear is Required")]
        public string OpeningYear { get; set; }
        public int MinimumTaxTypeId { get; set; }
        
        [Required(ErrorMessage = "Month of Operation is Required")]
        public int MonthOfOperation { get; set; }
        [Required(ErrorMessage = "UnRelievedCf is Required")]
        public decimal UnRelievedCf { get; set; }
        [Required(ErrorMessage = "LossCf is Required")]
        public decimal LossCf { get; set; }

        [Required(ErrorMessage = "Month of Operation is Required")]
        public decimal DeferredTaxBroughtFoward { get; set; }
    }
}
