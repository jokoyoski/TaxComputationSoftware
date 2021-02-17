namespace TaxComputationSoftware.Dtos
{
    public class IncomeListDto
    {
       public int TrialBalanceId { get; set; }

        public bool  IsCredit { get; set; }

        public bool IsDebit { get; set; }

        public bool IsBoth { get; set; }
    }
}