

using System.Collections.Generic;
using TaxComputationAPI.Helpers.Response;

namespace TaxComputationSoftware.Respoonse
{
    public class MinimumTaxResponse :  Response<List<MinimumTax>>
    {

    }

    public class MinimumTax
    {
        public string Name { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}