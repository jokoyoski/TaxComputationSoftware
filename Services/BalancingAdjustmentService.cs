using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using TaxComputationAPI.Response;
using TaxComputationAPI.Dto;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Repositories;

namespace TaxComputationAPI.Services
{
    public class BalancingAdjustmentService : IBalancingAdjustmentService
    {

        private readonly IUtilitiesService _utilitiesService;
        private readonly IBalancingAdjustmentRepository _balancingAdjustmentRepository;
        private readonly IMapper _mapper;

        public BalancingAdjustmentService(IUtilitiesService utilitiesService, IBalancingAdjustmentRepository balancingAdjustmentRepository, IMapper mapper)
        {
            _utilitiesService = utilitiesService;
            _balancingAdjustmentRepository = balancingAdjustmentRepository;
            _mapper = mapper;
        }

        public async Task<AddBalancingAdjustmentResponse> DisplayBalancingAdjustment(int companyId, string year)
        {
            if (companyId <= 0)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.BadRequest.ToString(),
                    ResponseDescription = "Invalid companyId"
                };
            }

            if (string.IsNullOrEmpty(year))
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.BadRequest.ToString(),
                    ResponseDescription = "Invalid year"
                };
            }

            var balancingAdjustment = await _balancingAdjustmentRepository.GetBalancingAdjustment(companyId, year);

            var result = new AddBalancingAdjustmentResponse();
            result.values = new List<Response.BalancingAdjustment>();

            try
            {
                foreach (var item in balancingAdjustment)
                {
                    var asset = await _utilitiesService.GetAssetMappingById(item.AssetId);
                    var balanceAdj = new TaxComputationAPI.Response.BalancingAdjustment
                    {
                        AssetId = asset.Id,
                        AssetName = asset.AssetName
                    };

                    var balanceAdjYearBought = await _balancingAdjustmentRepository.GetBalancingAdjustmentYeatBought(item.Id, balanceAdj.AssetId);

                    var returnBalancingAdjustment = _mapper.Map<List<TaxComputationAPI.Response.YearBoughtAdjustment>>(balanceAdjYearBought);

                    balanceAdj.AssetYear = returnBalancingAdjustment;
                    result.values.Add(balanceAdj);
                }

                result.ResponseCode = HttpStatusCode.OK.ToString();
                result.ResponseDescription = "SUCCESSFUL";
            }
            catch (Exception e)
            {
                result.ResponseCode = HttpStatusCode.ExpectationFailed.ToString();
                result.ResponseDescription = $"AN EXCEPTION OCCURRED: {e.Message}";
            }

            return result;
        }

        public async Task<AddBalancingAdjustmentResponse> AddBalanceAdjustment(AddBalanceAdjustmentDto addBalanceAdjustmentDto)
        {
            if (addBalanceAdjustmentDto == null)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.BadRequest.ToString(),
                    ResponseDescription = "balancing adjustment object is null"
                };
            }

            if (addBalanceAdjustmentDto.AssetId <= 0)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.BadRequest.ToString(),
                    ResponseDescription = "AssetId is less than or equal 0"
                };
            }


            try
            {
                var assetClass = await _utilitiesService.GetAssetMappingById(addBalanceAdjustmentDto.AssetId);

                if (assetClass == null)
                {
                    return new AddBalancingAdjustmentResponse
                    {
                        ResponseCode = HttpStatusCode.NotFound.ToString(),
                        ResponseDescription = "Asset class not found"
                    };
                }

                int initailRatio = assetClass.Initial;
                int annualRatio = assetClass.Annual;

                int assetLifeSpan = (int)100 / annualRatio;

                int.TryParse(addBalanceAdjustmentDto.Year, out int year);
                int.TryParse(addBalanceAdjustmentDto.YearBought, out int assetYear);

                int assetLifeCycle = (year - assetYear);

                decimal residue = 0;

                Tuple<BalancingAdjustment, decimal> balancingAdjustment = null;

                if (assetLifeCycle > assetLifeSpan)
                {
                    var rand = new Random();
                    residue = rand.Next(10, 100);

                    balancingAdjustment = CalculateBalancingAdjustment(addBalanceAdjustmentDto.SalesProceed, residue);

                    var b1 = new TaxComputationAPI.Models.BalancingAdjustment
                    {
                        AssetId = addBalanceAdjustmentDto.AssetId,
                        ComapnyId = addBalanceAdjustmentDto.CompanyId,
                        DateCreated = DateTime.UtcNow,
                        Year = addBalanceAdjustmentDto.Year,
                    };

                    var r1 = await _balancingAdjustmentRepository.SaveBalancingAdjustment(b1);

                    var bb1 = new TaxComputationAPI.Models.BalancingAdjustmentYearBought
                    {
                        Residue = residue,
                        AssestId = addBalanceAdjustmentDto.AssetId,
                        InitialAllowance = 0,
                        AnnualAllowance = 0,
                        SalesProceed = addBalanceAdjustmentDto.SalesProceed,
                        BalancingAdjustmentId = b1.Id
                    };

                    if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingAllowance) bb1.BalancingAllowance = balancingAdjustment.Item2;

                    if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingCharge) bb1.BalancingCharge = balancingAdjustment.Item2;

                    var ba1 = await _balancingAdjustmentRepository.SaveBalancingAdjustmentYeatBought(bb1);

                    return new AddBalancingAdjustmentResponse
                    {
                        ResponseCode = HttpStatusCode.OK.ToString(),
                        ResponseDescription = "N/B: Asset exceeded it's lifespan"
                    };
                }

                if (assetLifeCycle == 0)
                {
                    residue = addBalanceAdjustmentDto.Cost;

                    balancingAdjustment = CalculateBalancingAdjustment(addBalanceAdjustmentDto.SalesProceed, residue);

                    var b2 = new TaxComputationAPI.Models.BalancingAdjustment
                    {
                        AssetId = addBalanceAdjustmentDto.AssetId,
                        ComapnyId = addBalanceAdjustmentDto.CompanyId,
                        DateCreated = DateTime.UtcNow,
                        Year = addBalanceAdjustmentDto.Year,
                    };

                    var r2 = await _balancingAdjustmentRepository.SaveBalancingAdjustment(b2);

                    var bb2 = new TaxComputationAPI.Models.BalancingAdjustmentYearBought
                    {
                        Residue = residue,
                        AssestId = addBalanceAdjustmentDto.AssetId,
                        InitialAllowance = 0,
                        AnnualAllowance = 0,
                        SalesProceed = addBalanceAdjustmentDto.SalesProceed,
                        BalancingAdjustmentId = b2.Id
                    };

                    if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingAllowance) bb2.BalancingAllowance = balancingAdjustment.Item2;

                    if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingCharge) bb2.BalancingCharge = balancingAdjustment.Item2;

                    var ba2 = await _balancingAdjustmentRepository.SaveBalancingAdjustmentYeatBought(bb2);

                    return new AddBalancingAdjustmentResponse
                    {
                        ResponseCode = HttpStatusCode.OK.ToString(),
                        ResponseDescription = "Balancing Adjustment successfully calculate"
                    };
                }

                var initialCost = CalculateInitialAllowance(addBalanceAdjustmentDto.Cost, initailRatio, assetLifeCycle, assetLifeSpan);

                var annualCost = CalculateAnnualAllowance(addBalanceAdjustmentDto.Cost, initialCost, annualRatio, assetLifeCycle, assetLifeSpan);

                residue = CaluclateResidue(addBalanceAdjustmentDto.Cost, initialCost, annualCost);

                balancingAdjustment = CalculateBalancingAdjustment(addBalanceAdjustmentDto.SalesProceed, residue);

                var b3 = new TaxComputationAPI.Models.BalancingAdjustment
                {
                    AssetId = addBalanceAdjustmentDto.AssetId,
                    ComapnyId = addBalanceAdjustmentDto.CompanyId,
                    DateCreated = DateTime.UtcNow,
                    Year = addBalanceAdjustmentDto.Year,
                };

                var r3 = await _balancingAdjustmentRepository.SaveBalancingAdjustment(b3);

                var bb3 = new TaxComputationAPI.Models.BalancingAdjustmentYearBought
                {
                    Residue = residue,
                    AssestId = addBalanceAdjustmentDto.AssetId,
                    InitialAllowance = initialCost,
                    AnnualAllowance = annualCost,
                    SalesProceed = addBalanceAdjustmentDto.SalesProceed,
                    BalancingAdjustmentId = b3.Id
                };

                if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingAllowance) bb3.BalancingAllowance = balancingAdjustment.Item2;

                if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingCharge) bb3.BalancingCharge = balancingAdjustment.Item2;

                var ba3 = await _balancingAdjustmentRepository.SaveBalancingAdjustmentYeatBought(bb3);

                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.OK.ToString(),
                    ResponseDescription = "Balancing Adjustment successfully calculate"
                };

            }
            catch (Exception e)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.ExpectationFailed.ToString(),
                    ResponseDescription = $"AN EXCEPTION OCCURRED: {e.Message}"
                };
            }
        }

        private static decimal CalculateInitialAllowance(decimal cost, int initialRatio, int assetLifeCycle, int assetLifeSpan)
        {
            if (assetLifeCycle == assetLifeSpan)
            {
                return cost * (initialRatio / 100);
            }

            return 0;
        }

        private static decimal CalculateAnnualAllowance(decimal cost, decimal initialCost, int annualRatio, int assetLifeCycle, int assetLifeSpan)
        {
            if (assetLifeCycle < assetLifeSpan)
            {
                return 0;
            }

            return (cost - initialCost) * (annualRatio / 100) * assetLifeSpan;
        }

        private static Tuple<BalancingAdjustment, decimal> CalculateBalancingAdjustment(decimal salesProceed, decimal residue)
        {
            decimal value = 0;

            if (salesProceed < residue)
            {
                value = residue - salesProceed;
                return new Tuple<BalancingAdjustment, decimal>(BalancingAdjustment.BalancingAllowance, value);
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
            BalancingAllowance = 0,
            BalancingCharge = 1

        }
    }
}