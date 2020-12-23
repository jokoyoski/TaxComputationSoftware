
using System.Collections.Generic;
using TaxComputationAPI.Dtos;

namespace TaxComputationSoftware.Dtos
{
    public class CreateDeferredTax
    {

        public int FairValueGainId { get; set; }

        public List<TrialBalanceValue> TrialBalanceList { get; set; }

        public int CompanyId { get; set; }

        public int YearId { get; set; }
    }

}