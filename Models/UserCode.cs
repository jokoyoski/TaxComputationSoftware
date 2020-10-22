using System;

namespace TaxComputationSoftware.Models
{
    public class UserCode
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public DateTime DateCreated { get; set; }
    }
}