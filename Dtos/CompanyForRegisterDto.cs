using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class CompanyForRegisterDto
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "You must specify description between 10 and 20 characters")]
        public string CompanyDescription { get; set; }
        [Required(ErrorMessage = "CacNumber is Required")]
        public string CacNumber { get; set; }
        [Required(ErrorMessage = "TinNumber is Required")]
        public string TinNumber { get; set; }
    }
}
