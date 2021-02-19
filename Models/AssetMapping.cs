using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class AssetMapping
    {
        [Key]
        public int Id { get; set; }
        public string AssetName { get; set; }
        public int Initial { get; set; }
        public int Annual { get; set; }
    }
}
