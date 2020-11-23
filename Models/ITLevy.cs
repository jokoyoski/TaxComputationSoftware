using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Models
{
    public class ITLevy
    {
        [Key]
        public int Id { get; set; }

        public string Item { get; set; }
    }
}
