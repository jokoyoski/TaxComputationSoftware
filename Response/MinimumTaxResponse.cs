

using System.Collections.Generic;
using TaxComputationAPI.Helpers.Response;

namespace TaxComputationSoftware.Respoonse
{
    public class MinimumTaxResponse :  Response<List<MinimumTaxDisplay>>
    {

    }

    public class MinimumTaxDisplay
    {
        public string Name { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public bool CanDelete   {get;set;}
        public bool CanBolden {get;set;}
        public bool CanUnderlineUpColumn1 {get;set;}
        public bool CanUnderlineDownColumn1 {get;set;}
         public bool CanUnderlineDownColumn2 {get;set;}
        public bool CanUnderlineUpColumn2 {get;set;}
    }
}