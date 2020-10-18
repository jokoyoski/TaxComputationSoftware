namespace TaxComputationAPI.Models
{
    public class TrialBalance
    {
    
        public int Id {get;set;}

        public string AccountId { get; set; }
        
        public string Item {get;set;}

        public decimal Debit {get;set;}

        public decimal Credit {get;set;}

        public  string MappedTo {get;set;}

        public bool IsCheck {get;set;}
        
        public int TrackId { get; set; }
    }
}