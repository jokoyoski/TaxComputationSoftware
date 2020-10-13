using System.Collections.Generic;

namespace TaxComputationAPI.Dtos
{
    public class FixedAssetDto
    {
        public List<FixedAssetListDto>  values {get;set;}

        public List<NetBookValue> netBookValue {get;set;}

        public Total total {get;set;}
    }
}