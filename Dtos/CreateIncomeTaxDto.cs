using System.Collections.Generic;

namespace TaxComputationSoftware.Dtos
{
    public class CreateIncomeTaxDto
    {
        public decimal LossBroughtFoward { get; set; }
        public int TypeId { get; set; }
        public int YearId { get; set; }
        public decimal UnrelievedCapitalAllowanceBroughtFoward { get; set; }
        public List<IncomeListDto> IncomeList { get; set; }

        public int CompanyId { get; set; }
    }
}