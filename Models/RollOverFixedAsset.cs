using System.Collections.Generic;
using TaxComputationAPI.ResponseModel;

namespace TaxComputationSoftware.Models
{
    public class RollOverFixedAsset
    {
        public FixedAssetResponse fixedAssetResponse { get; set; }

        public List<decimal> costs { get; set; }

        public List<decimal> depreciations { get; set; }

    }
}