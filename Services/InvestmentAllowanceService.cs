using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;

namespace TaxComputationAPI.Services
{
    public class InvestmentAllowanceService : IInvestmentAllowanceService
    {
        private readonly IUtilitiesService _utilitiesService;
        private readonly IFixedAssetRepository _fixedAssetRepository;
        private readonly IInvestmentAllowanceRepository _investmentAllowanceRepository;
        public InvestmentAllowanceService(IUtilitiesService utilitiesService, IFixedAssetRepository fixedAssetRepository, IInvestmentAllowanceRepository investmentAllowanceRepository)
        {
            _utilitiesService = utilitiesService;
            _fixedAssetRepository = fixedAssetRepository;
            _investmentAllowanceRepository = investmentAllowanceRepository;

        }

        public async Task AddInvestmentAllowanceAsync(InvestmentAllowance investmentAllowance)
        {
            if (investmentAllowance == null)
            {
                throw new ArgumentNullException(nameof(investmentAllowance));
            }


            await _investmentAllowanceRepository.AddInvestmentAllowanceAsync(investmentAllowance);
        }

        public async Task DeleteInvestmentAllowanceAsync(int Id)
        {
           

            await _investmentAllowanceRepository.DeleteInvestmentAllowanceAsync(Id);
        }



        public async Task<InvestmentAllowanceListDto> GetInvestmentAllowances(int companyId, int yearId)
        {
           
            var investmentList = new InvestmentAllowanceListDto();
            investmentList.Investments= new List<Investment>();
            decimal totalAddition = 0;
            decimal percentage = (decimal)10 / 100;     //annual percentage rate
            var values = await _investmentAllowanceRepository.GetInvestmentAlowanceByCompanyIdYearId(companyId, yearId);
            if(values.Count==0){
                return null;
            }
            foreach (var value in values)
            {
                 var investment = new Investment();
                var addition = await _fixedAssetRepository.GetFixedAssetsByCompanyYearIdAssetId(value.CompanyId, value.YearId, value.AssetId);
                 
                if (addition != null)
                {
                    var assetValue = await _utilitiesService.GetAssetMappingById(addition.AssetId);
                    totalAddition += addition.CostAddition;
                    investment.Name = assetValue.AssetName;
                    investment.Id=value.Id;
                    investment.Amount = $"₦{Utilities.FormatAmount(addition.CostAddition)}";
                    investmentList.Investments.Add(investment);
                }

                var percent = totalAddition * percentage;
                investmentList.InvestmentAllowanceatTenPercent=$"₦{Utilities.FormatAmount(percent)}";
            }
              return investmentList;

          
        }
    }
}
