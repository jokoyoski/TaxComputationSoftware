using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class AssetMappingDeleteDto
    {
        [Required]
        public string AssetName { get; set; }

        [Required]
        public int Initial { get; set; }
        [Required]
        public int Annual { get; set; }
    }
}
