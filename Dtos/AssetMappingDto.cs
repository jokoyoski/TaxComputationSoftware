using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class AssetMappingDto
    {
        public string AssetName { get; set; }
        public int Initial { get; set; }
        public int Annual { get; set; }
    }
}
