

using System;

namespace TaxComputationAPI.Models
{
    public class TrackTrialBalance
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int YearId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}