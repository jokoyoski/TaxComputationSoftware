

using System;

namespace TaxComputationAPI.Models
{
    public class BalancingAdjustment
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int ComapnyId { get; set; }
        public string Year { get; set; }
        public DateTime DateCreated { get; set; }
    }
}