namespace TaxComputationAPI.Models
{
    public class TrialBalance
    {
    
        public int Id {get;set;}
        public string Item {get;set;}

        public long Debit {get;set;}

        public long Credit {get;set;}

        public  string MappedTo {get;set;}

        public bool IsCheck {get;set;}
    }
}