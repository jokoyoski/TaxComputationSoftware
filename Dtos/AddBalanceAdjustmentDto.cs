
namespace TaxComputationAPI.Dto
{
    public class AddBalanceAdjustmentDto
    {
        public string Year { get; set; }
        public int AssetId { get; set; }
        public decimal Cost { get; set; }
        public decimal SalesProceed { get; set; }
        public string YearBought { get; set; }
        public int CompanyId { get; set; }
    }
}