namespace TaxComputationAPI.Dtos
{
    public class CreateFixedAssetDto
    {
        public int  AssetId {get;set;}

        public int FinancialYearId {get;set;}

        public int CompanyId {get;set;}

        public string Addition {get;set;}

        public string Disposal {get;set;}

        public   string OpeningBalance {get;set;}

        public string ClosingBalance {get;set;}

        public bool IsCost {get;set;}
    }
}