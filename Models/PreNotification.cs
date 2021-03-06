

using System;

namespace TaxComputationSoftware.Model
{
    public class PreNotification
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; } 
        public DateTime JobDate { get; set; }
        public bool IsLocked { get; set; }
    }
}