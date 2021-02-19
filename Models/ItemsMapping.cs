using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class ItemsMapping
    {
        [Key]
        public int Id { get; set; }
        public string MappedCode { get; set; }
        public string ItemValue { get; set; }
    }
}
