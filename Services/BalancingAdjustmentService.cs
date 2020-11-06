using System;
using System.Threading.Tasks;
using TaxComputation.Response;
using TaxComputationAPI.Services;
using TaxComputationSoftware.Dto;
using TaxComputationSoftware.Interface;

namespace TaxComputation.Services
{
    public class BalancingAdjustmentService : IBalancingAdjustmentService
    {

        private readonly UtilitiesService _utilitiesService;
        
        public BalancingAdjustmentService(UtilitiesService utilitiesService)
        {
            _utilitiesService = utilitiesService;
        }

        public async Task<AddBalancingAdjustmentResponse> AddBalanceAdjustment(AddBalanceAdjustmentDto addBalanceAdjustmentDto)
        {
            if(addBalanceAdjustmentDto == null)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = "",
                    ResponseDescription = "balancing adjustment object is null"
                    
                };
            }

            if(addBalanceAdjustmentDto.AssetId <= 0)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = "",
                    ResponseDescription = "AssetId is less than or equal 0"
                    
                };
            }

            var assetClass = await _utilitiesService.GetAssetMappingById(addBalanceAdjustmentDto.AssetId); 

            if(assetClass == null)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = "",
                    ResponseDescription = "Asset class not found"
                    
                };
            }

            int initailRatio = assetClass.Initial;
            int annualRatio = assetClass.Annual;

            int assetLifeSpan = (int) 100/annualRatio;

            int.TryParse(addBalanceAdjustmentDto.Year, out int year);
            int.TryParse(addBalanceAdjustmentDto.YearBought, out int assetYear);

            int assetLifeCycle = (year - assetYear);

            decimal residue = 0;

            Tuple<BalancingAdjustment,decimal> balancingAdjustment = null;

            if(assetLifeCycle > assetLifeSpan)
            {
                var rand = new Random();
                residue = rand.Next(10, 100);

                balancingAdjustment = CalculateBalancingAdjustment(addBalanceAdjustmentDto.SalesProceed, residue);
                
                //TODO: Olumide - Save to Balanacing Adjustment table and BalancingAdjustment Year Bought Table in repository

                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = "",
                    ResponseDescription = "N/B: Asset exceeded it's lifespan"
                };   
            }

            if(assetLifeCycle == 0)
            {
                residue = addBalanceAdjustmentDto.Cost;

                balancingAdjustment = CalculateBalancingAdjustment(addBalanceAdjustmentDto.SalesProceed, residue);
                
                //TODO: Olumide - Save to Balanacing Adjustment table and BalancingAdjustment Year Bought Table in repository

                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = "",
                    ResponseDescription = "Balancing Adjustment successfully calculate"
                };   
            }

            var initialCost = CalculateInitialAllowance(addBalanceAdjustmentDto.Cost, initailRatio, assetLifeCycle, assetLifeSpan);

            var annualCost = CalculateAnnualAllowance(addBalanceAdjustmentDto.Cost, initialCost, annualRatio, assetLifeCycle, assetLifeSpan);

            residue = CaluclateResidue(addBalanceAdjustmentDto.Cost, initialCost, annualCost);

            balancingAdjustment = CalculateBalancingAdjustment(addBalanceAdjustmentDto.SalesProceed, residue);

            //TODO: Olumide - Save to Balanacing Adjustment table and BalancingAdjustment Year Bought Table in repository

            return new AddBalancingAdjustmentResponse
            {
                ResponseCode = "",
                ResponseDescription = "Balancing Adjustment successfully calculate"
            };
        }

        private static decimal CalculateInitialAllowance(decimal cost, int initialRatio, int assetLifeCycle, int assetLifeSpan)
        {
            if(assetLifeCycle == assetLifeSpan)
            {
                return cost*(initialRatio/100);
            }

            return 0;
        }

        private static decimal CalculateAnnualAllowance(decimal cost, decimal initialCost, int annualRatio, int assetLifeCycle, int assetLifeSpan)
        {
            if(assetLifeCycle < assetLifeSpan)
            {
                return 0;
            }

            return (cost-initialCost)*(annualRatio/100)*assetLifeSpan;
        }

        private static Tuple<BalancingAdjustment, decimal> CalculateBalancingAdjustment(decimal salesProceed, decimal residue)
        {
            decimal value = 0;

            if(salesProceed < residue)
            {
                value = residue - salesProceed;
                return new Tuple<BalancingAdjustment, decimal>(BalancingAdjustment.BalanceAllowance, value);
            }
            
            value = salesProceed - residue;
            
            return new Tuple<BalancingAdjustment, decimal>(BalancingAdjustment.BalancingCharge, value);
        }

        private static decimal CaluclateResidue(decimal cost, decimal initial, decimal annual)
        {
            return (cost - initial - annual);
        }

        public enum BalancingAdjustment
        {
            BalanceAllowance = 0,
            BalancingCharge = 1

        }
    }
}