using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using TaxComputationAPI.Response;
using TaxComputationAPI.Dto;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Repositories;
using System.Linq;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services
{
    public class BalancingAdjustmentService : IBalancingAdjustmentService
    {
        private readonly IUtilitiesService _utilitiesService;
        private readonly IBalancingAdjustmentRepository _balancingAdjustmentRepository;
        private readonly ICompaniesRepository _companies;
        private readonly ICapitalAllowanceService _capitalAllowanceService;
        private readonly IMapper _mapper;

        public BalancingAdjustmentService(IUtilitiesService utilitiesService, ICapitalAllowanceService capitalAllowanceService, IBalancingAdjustmentRepository balancingAdjustmentRepository, ICompaniesRepository companies, IMapper mapper)
        {
            _utilitiesService = utilitiesService;
            _balancingAdjustmentRepository = balancingAdjustmentRepository;
            _companies = companies;
            _capitalAllowanceService = capitalAllowanceService;
            _mapper = mapper;
        }

        public async Task<AddBalancingAdjustmentResponse> DisplayBalancingAdjustment(int companyId, string year)
        {
            if (companyId <= 0)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.BadRequest,
                    Code = "10",
                    ResponseDescription = "Invalid companyId"
                };
            }

            if (string.IsNullOrEmpty(year))
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.BadRequest,
                    Code = "10",
                    ResponseDescription = "Invalid year"
                };
            }

            var balancingAdjustment = await _balancingAdjustmentRepository.GetBalancingAdjustment(companyId, year);

            if(balancingAdjustment == null)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.NotFound,
                    Code = "01",
                    ResponseDescription = "No Balancing Adjustment"
                };
            }
            var company = await _companies.GetCompanyAsync(companyId);

            var result = new AddBalancingAdjustmentResponse();
            result.Values = new BalancingAdjustmentDisplay();
            result.Values.Company = company.CompanyName;
            result.Values.BalancingAdjustmentYear = year;
            result.Values.BalancingAdjustments = new List<Response.BalancingAdjustment>();
            

            try
            {
                var balanceAdjList = new List<TaxComputationAPI.Response.BalancingAdjustment>();

                foreach(var item in balancingAdjustment)
                {
                    var asset = await _utilitiesService.GetAssetMappingById(item.AssetId);
                    
                    var balanceAdj = new TaxComputationAPI.Response.BalancingAdjustment
                    {
                        Id = item.Id,
                        AssetId = asset.Id,
                        AssetName = asset.AssetName
                    };

                    balanceAdjList.Add(balanceAdj);
                }

                foreach (var item in balanceAdjList)
                {
                    var balanceAdjYearBought = await _balancingAdjustmentRepository.GetBalancingAdjustmentYeatBought(item.Id, item.AssetId);

                    var returnBalancingAdjustment = _mapper.Map<List<TaxComputationAPI.Response.YearBoughtAdjustment>>(balanceAdjYearBought);

                    item.AssetYear = returnBalancingAdjustment;
                }

                result.Values.BalancingAdjustments = balanceAdjList;
                result.ResponseCode = HttpStatusCode.OK;
                result.Code = "00";
                result.ResponseDescription = "SUCCESSFUL";
            }
            catch (Exception e)
            {
                result.ResponseCode = HttpStatusCode.ExpectationFailed;
                result.Code = "11";
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
                    ResponseCode = HttpStatusCode.BadRequest,
                    Code = "12",
                    ResponseDescription = "balancing adjustment object is null"
                };
            }

            if (addBalanceAdjustmentDto.AssetId <= 0)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.BadRequest,
                    Code = "12",
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
                        ResponseCode = HttpStatusCode.BadRequest,
                        Code = "10",
                        ResponseDescription = "Asset class not found"
                    };
                }

                var balanceAdjEx = await _balancingAdjustmentRepository.GetBalancingAdjustment(addBalanceAdjustmentDto.CompanyId, addBalanceAdjustmentDto.Year);

                Models.BalancingAdjustment assetBalancing = default(Models.BalancingAdjustment);

                if (balanceAdjEx != null)
                {
                    assetBalancing = balanceAdjEx.Where(p => p.AssetId == assetClass.Id).SingleOrDefault();
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
                        CompanyId = addBalanceAdjustmentDto.CompanyId,
                        DateCreated = DateTime.Now,
                        Year = addBalanceAdjustmentDto.Year,
                    };
                    
                    if(assetBalancing == null) await _balancingAdjustmentRepository.SaveBalancingAdjustment(b1);

                    var balList = await _balancingAdjustmentRepository.GetBalancingAdjustment(b1.CompanyId, b1.Year);

                    b1 = balList.LastOrDefault();

                    var bb1 = new TaxComputationAPI.Models.BalancingAdjustmentYearBought
                    {
                        Cost = addBalanceAdjustmentDto.Cost,
                        Residue = residue,
                        AssestId = addBalanceAdjustmentDto.AssetId,
                        InitialAllowance = 0,
                        AnnualAllowance = 0,
                        SalesProceed = addBalanceAdjustmentDto.SalesProceed,
                        BalancingAdjustmentId = assetBalancing == null ? b1.Id : assetBalancing.Id,
                        YearBought = addBalanceAdjustmentDto.YearBought,
                        DateCreated = DateTime.Now
                    };

                    if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingAllowance) bb1.BalancingAllowance = balancingAdjustment.Item2;

                    if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingCharge) bb1.BalancingCharge = balancingAdjustment.Item2;

                    var ba1 = await _balancingAdjustmentRepository.SaveBalancingAdjustmentYeatBought(bb1);
                    await  _capitalAllowanceService.SaveCapitalAllowanceFromBalancingAdjustment(residue, addBalanceAdjustmentDto.YearBought, addBalanceAdjustmentDto.CompanyId, addBalanceAdjustmentDto.AssetId);

                    return new AddBalancingAdjustmentResponse
                    {
                        ResponseCode = HttpStatusCode.OK,
                        Code = "00",
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
                        CompanyId = addBalanceAdjustmentDto.CompanyId,
                        DateCreated = DateTime.UtcNow,
                        Year = addBalanceAdjustmentDto.Year,
                    };

                    if(assetBalancing == null) await _balancingAdjustmentRepository.SaveBalancingAdjustment(b2);

                    var balList0 = await _balancingAdjustmentRepository.GetBalancingAdjustment(b2.CompanyId, b2.Year);

                    b2 = balList0.LastOrDefault();

                    var bb2 = new TaxComputationAPI.Models.BalancingAdjustmentYearBought
                    {
                        Cost = addBalanceAdjustmentDto.Cost,
                        Residue = residue,
                        AssestId = addBalanceAdjustmentDto.AssetId,
                        InitialAllowance = 0,
                        AnnualAllowance = 0,
                        SalesProceed = addBalanceAdjustmentDto.SalesProceed,
                        BalancingAdjustmentId = assetBalancing == null ? b2.Id : assetBalancing.Id,
                        YearBought = addBalanceAdjustmentDto.YearBought,
                        DateCreated = DateTime.UtcNow
                    };

                    if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingAllowance) bb2.BalancingAllowance = balancingAdjustment.Item2;

                    if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingCharge) bb2.BalancingCharge = balancingAdjustment.Item2;

                    var ba2 = await _balancingAdjustmentRepository.SaveBalancingAdjustmentYeatBought(bb2);
                    await  _capitalAllowanceService.SaveCapitalAllowanceFromBalancingAdjustment(residue, addBalanceAdjustmentDto.YearBought, addBalanceAdjustmentDto.CompanyId, addBalanceAdjustmentDto.AssetId);

                   return new AddBalancingAdjustmentResponse
                   {
                        ResponseCode = HttpStatusCode.OK,
                        Code = "00",
                        ResponseDescription = "Balancing Adjustment successfully calculated"
                    };
                }

                var initialCost = CalculateInitialAllowance(addBalanceAdjustmentDto.Cost, initailRatio, assetLifeCycle, assetLifeSpan);

                var annualCost = CalculateAnnualAllowance(addBalanceAdjustmentDto.Cost, initialCost, annualRatio, assetLifeCycle, assetLifeSpan);

                residue = CaluclateResidue(addBalanceAdjustmentDto.Cost, initialCost, annualCost);

                balancingAdjustment = CalculateBalancingAdjustment(addBalanceAdjustmentDto.SalesProceed, residue);

                var b3 = new TaxComputationAPI.Models.BalancingAdjustment
                {
                    AssetId = addBalanceAdjustmentDto.AssetId,
                    CompanyId = addBalanceAdjustmentDto.CompanyId,
                    DateCreated = DateTime.Now,
                    Year = addBalanceAdjustmentDto.Year,
                };

                if(assetBalancing == null) await _balancingAdjustmentRepository.SaveBalancingAdjustment(b3);

                var balList1 = await _balancingAdjustmentRepository.GetBalancingAdjustment(b3.CompanyId, b3.Year);

                b3 = balList1.LastOrDefault();

                var bb3 = new TaxComputationAPI.Models.BalancingAdjustmentYearBought
                {
                    Cost = addBalanceAdjustmentDto.Cost,
                    Residue = residue,
                    AssestId = addBalanceAdjustmentDto.AssetId,
                    InitialAllowance = initialCost,
                    AnnualAllowance = annualCost,
                    SalesProceed = addBalanceAdjustmentDto.SalesProceed,
                    BalancingAdjustmentId = assetBalancing == null ? b3.Id : assetBalancing.Id,
                    YearBought = addBalanceAdjustmentDto.YearBought,
                    DateCreated=DateTime.Now
                };

                if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingAllowance) bb3.BalancingAllowance = balancingAdjustment.Item2;

                if (balancingAdjustment.Item1 == BalancingAdjustment.BalancingCharge) bb3.BalancingCharge = balancingAdjustment.Item2;

                var ba3 = await _balancingAdjustmentRepository.SaveBalancingAdjustmentYeatBought(bb3);
                await  _capitalAllowanceService.SaveCapitalAllowanceFromBalancingAdjustment(residue, addBalanceAdjustmentDto.YearBought, addBalanceAdjustmentDto.CompanyId, addBalanceAdjustmentDto.AssetId);

                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.OK,
                    Code = "00",
                    ResponseDescription = "Balancing Adjustment successfully calculated"
                };
            }
            catch (Exception e)
            {
                return new AddBalancingAdjustmentResponse
                {
                    ResponseCode = HttpStatusCode.ExpectationFailed,
                    Code = "11",
                    ResponseDescription = $"AN EXCEPTION OCCURRED: {e.Message}"
                };
            }
        }

        private static decimal CalculateInitialAllowance(decimal cost, int initialRatio, int assetLifeCycle, int assetLifeSpan)
        {
            var value = (cost * initialRatio) / 100;
            return value;
        }

        private static decimal CalculateAnnualAllowance(decimal cost, decimal initialCost, int annualRatio, int assetLifeCycle, int assetLifeSpan)
        {
            var value = initialCost / assetLifeSpan * assetLifeCycle;
            return value;
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
            var value = (cost - initial - annual);
            var rand = new Random();
            if(value < 10) value = rand.Next(10, 100);
            
            return value;
        }

        public enum BalancingAdjustment
        {
            BalancingAllowance = 0,
            BalancingCharge = 1

        }

        public async Task<BalancingAdjustmentYearBoughtResponse> DeleteBalancingAdjustmentYearBoughtAsync(int balancingAdjustmentYearBoughtId)
        {
            if (balancingAdjustmentYearBoughtId <= 0)
            {
                return new BalancingAdjustmentYearBoughtResponse
                {
                    ResponseCode = HttpStatusCode.BadRequest,
                    Code = "10",
                    ResponseDescription = $"{balancingAdjustmentYearBoughtId} is invalid"
                };
            }

            try
            {
                var yearBought = await _balancingAdjustmentRepository.GetBalancingAdjustmentYearBoughtById(balancingAdjustmentYearBoughtId);

                if(yearBought == null)
                {
                    return new BalancingAdjustmentYearBoughtResponse
                    {
                        ResponseCode = HttpStatusCode.NotFound,
                        Code = "12",
                        ResponseDescription = $"Data not found"
                    };
                }

                await _balancingAdjustmentRepository.DeleteBalancingAdjustmentYearBoughtAsync(yearBought);
            }
            catch(Exception e)
            {
                return new BalancingAdjustmentYearBoughtResponse
                {
                    ResponseCode = HttpStatusCode.ExpectationFailed,
                    Code = "11",
                    ResponseDescription = $"AN EXCEPTION OCCURRED: {e.Message}"
                };
            }

            return new BalancingAdjustmentYearBoughtResponse
            {
                ResponseCode = HttpStatusCode.OK,
                Code = "00",
                ResponseDescription = "Balancing adjustment year bought deleted successfully"
            };
            
        }
    }
}