

using System;

namespace TaxComputationSoftware.Model
{
    public class MinimumTaxModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int FinancialYearId { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal NetAsset { get; set; }
        public decimal ShareCapital { get; set; }
        public decimal TurnOver { get; set; }
        public decimal Revenue { get; set; }
        public decimal MinimumTaxPayable { get; set; }
        public DateTime DateCreated { get; set; }

    }
}