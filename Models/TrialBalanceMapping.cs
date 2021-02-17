namespace TaxComputationAPI.Models
{
    public class TrialBalanceMapping
    {
        public int Id {get;set;}

        public int TrialBalanceId {get;set;}

        public int ModuleId {get;set;}

        public string ModuleCode {get;set;}

        public string AdditionalInfo {get;set;}
    }
}