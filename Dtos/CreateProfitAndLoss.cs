using System;
using System.Collections.Generic;

namespace TaxComputationAPI.Dtos
{
    public class CreateProfitAndLoss
    {

        public int ProfitAndLossId { get; set; }

        public List<TrialBalance> TrialBalanceList { get; set; }

        public int CompanyId { get; set; }

        public int Year { get; set; }
    }






    public  class TrialBalance
    {
        public int TrialBalalnceId { get; set; }


        public bool IsDebit { get; set; }

        public bool IsBoth { get; set; }
    }
}
