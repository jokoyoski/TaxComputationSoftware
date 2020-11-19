using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class ProfitAndLossDto
    {
        public int Revenue { get; set; }
        public int OtherIncome { get; set; }
        public int CostOfSales { get; set; }
        public int OtherOperatingIncome { get; set; }
        public int OperatingExpense { get; set; }
        public int YearId { get; set; }
        public int CompanyId { get; set; }
        public int GrossProfit { get; set; }
        public int GrossLoss { get; set; }
        public int OtherOperatingGain { get; set; }
        public int OtherOperatingLoss { get; set; }
        public int LossBeforeTaxation { get; set; }
        public int ProfitBeforeTaxation { get; set; }
    }
}
