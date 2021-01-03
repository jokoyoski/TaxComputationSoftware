

using System;

namespace TaxComputationSoftware.Model
{
    public class PreNotification
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime JobDate { get; set; }
    }
}