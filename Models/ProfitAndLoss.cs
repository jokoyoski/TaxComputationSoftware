using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class ProfitAndLoss
    {
        [Key]
        public int Id { get; set; }
        public string Revenue { get; set; }
        public string CostOfSales { get; set; }
        public string OtherOperatingIncome { get; set; }
        public string OperatingExpenses { get; set; }
        public string OtherOperatingGainOrLoss { get; set; }
       
    }
}
