using System;
using System.Collections.Generic;

namespace TaxComputationAPI.Dtos
{
    public class CreateProfitAndLoss
    {

        public int ProfitAndLossId { get; set; }

        public List<TrialBalanceValue> TrialBalanceList { get; set; }

        public int CompanyId { get; set; }

        public int YearId { get; set; }

        public bool IsAllowable {get;set;}

        public bool IsDisAllowable {get;set;}

        public bool IsFairValueGain { get; set; }
    }






    public  class TrialBalanceValue
    {
        public int TrialBalanceId { get; set; }

        public bool  IsCredit { get; set; }

        public bool IsDebit { get; set; }

        public bool IsBoth { get; set; }
    }
}
