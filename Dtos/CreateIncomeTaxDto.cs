using System.Collections.Generic;

namespace TaxComputationSoftware.Dtos
{
    public class CreateIncomeTaxDto
    {
        public decimal LossBroughtFoward { get; set; }

        public decimal UnrelievedCapitalAllowanceBroughtFoward { get; set; }

        public List<int> TrialBalanceId { get; set; }
    }
}