using System;
using System.Collections.Generic;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;

namespace TaxComputationAPI.Dtos
{
    public class CapitalAllowanceDto
    {

        public List<CapitalAllowanceViewDto> capitalAllowances { get; set; }

        public decimal OpeningResidualTotal { get; set; }

        public decimal AdditionTotal { get; set; }

        public decimal DisposalTotal { get; set; }

        public decimal InitialTotal { get; set; }

        public decimal AnnualTotal { get; set; }

        public decimal TotalTotal { get; set; }

        public string NumberOfYearsAvailable { get; set; }
        public string CompanyCode { get; set; }
        public decimal ClosingResidueTotal { get; set; }
    }
}
