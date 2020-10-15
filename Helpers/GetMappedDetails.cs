using System.Collections.Generic;

namespace TaxComputationAPI.Helpers
{
    public class GetMappedDetails
    {
        public string MappedTo(string mappedId){

            Dictionary<string,string> modules =new Dictionary<string, string>();

            modules.Add("profitandloss","Profit and Loss");
            modules.Add("fixedasset","FIXED ASSET");
            modules.Add("incometax","INCOME TAX");
            modules.Add("deferredtax","DEFERREDTAX");

            var mappedDetails=modules.GetValueOrDefault(mappedId);

            return $"Mapped to {mappedDetails}";
        
    }

}
}