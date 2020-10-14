namespace TaxComputationAPI.Models
{
    public class FinancialYear
    {
        [Key]
        public int Id {get;set;}

        public string Name {get;set;}
    }
}