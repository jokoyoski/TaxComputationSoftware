using System;
using System.Collections.Generic;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Dtos
{
    public class CapitalAllowanceDto
    {

        public List<CapitalAllowance> capitalAllowances { get; set; }

        public  decimal OpeningResidualTotal { get; set; }

        public decimal AdditionTotal { get; set; }

        public decimal DisposalTotal { get; set; }

        public decimal InitialTotal { get; set; }

        public decimal AnnualTotal { get; set; }

        public decimal TotalTotal { get; set; }

        public decimal ClosingResidueTotal { get; set; }
    }
}
