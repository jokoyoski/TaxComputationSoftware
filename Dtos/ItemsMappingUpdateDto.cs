using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxComputationAPI.Dtos
{
    public class ItemsMappingUpdateDto
    {
        public string MappedCode { get; set; }
        public string ItemValue { get; set; }
    }
}
