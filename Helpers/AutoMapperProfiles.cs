using AutoMapper;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
             CreateMap<User, UserForLoginDto>().ReverseMap();
            CreateMap<Company, CompanyForListDto>().ReverseMap();
            CreateMap<Company, CompanyForRegisterDto>().ReverseMap();
            CreateMap<CreateFixedAssetDto, FixedAsset>().ReverseMap();
            CreateMap<AssetClassDto, AssetClass>().ReverseMap();
            CreateMap<FinancialYearDto, FinancialYear>().ReverseMap();
            CreateMap<AssetMapping, AssetMappingDto>().ReverseMap();
            CreateMap<AssetMapping, AssetMappingUpdateDto>().ReverseMap();
            CreateMap<AssetMapping, AssetMappingDeleteDto>().ReverseMap();
            CreateMap<ItemsMapping, ItemsMappingDto>().ReverseMap();
            CreateMap<ItemsMapping, ItemsMappingUpdateDto>().ReverseMap();
            CreateMap<ItemsMapping, ItemsMappingDeleteDto>().ReverseMap();
            CreateMap<TaxComputationAPI.Models.BalancingAdjustmentYearBought, TaxComputationAPI.Response.YearBoughtAdjustment>().ReverseMap();
            CreateMap<ProfitAndLoss, ProfitAndLossDto>().ReverseMap();
            CreateMap<ITLevy, ITLevyDto>().ReverseMap();
            CreateMap<ITLevy, ITLevyViewDto>().ReverseMap();
            CreateMap<MinimumTax, MinimumTaxDto>().ReverseMap();
            CreateMap<MinimumTax, MinimumTaxViewDto>().ReverseMap();
            CreateMap<InvestmentAllowance, InvestmentAllowanceDto>().ReverseMap();
            CreateMap<InvestmentAllowance, InvestmentAllowanceDeleteDto>().ReverseMap();
        }
    }
}