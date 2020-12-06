using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class ITLevy
    {
        [Key]
        public int Id { get; set; }
        public decimal ProfitBeforeTaxation { get; set; }
        public decimal ITLevyAt1PercentThereIn { get; set; }
    }
}
