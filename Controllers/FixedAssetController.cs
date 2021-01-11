using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FixedAssetController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFixedAssetService _fixedAssetService;

        private readonly ITrialBalanceService _trialBalanceService;
        private readonly IUtilitiesService _utilitiesService;
        private readonly ILogger<FixedAssetController> _logger;

        private readonly IMemoryCache _memoryCache;

        public FixedAssetController(IMapper mapper, IFixedAssetService fixedAssetService, IMemoryCache memoryCache, ITrialBalanceService trialBalanceService, IUtilitiesService utilitiesService, ILogger<FixedAssetController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _fixedAssetService = fixedAssetService;
            _utilitiesService = utilitiesService;
            _memoryCache = memoryCache;
            _trialBalanceService = trialBalanceService;
        }

        [HttpPost]
        //  [Authorize]
        public async Task<IActionResult> AddFixedAsset(CreateFixedAssetDto createFixed)
        {
            try
            {

                foreach (var j in createFixed.TriBalanceId)
                {
                    var trialBalanceRecord = await _trialBalanceService.GetTrialBalanceById(j);
                    if (trialBalanceRecord.IsCheck)
                    {
                        return StatusCode(400, new { errors = new[] { "One of the item selected has already been mapped, please reload" } });
                    }
                }

                var details = await _utilitiesService.GetFinancialYearAsync(createFixed.YearId);
                var companyDetails = await _utilitiesService.GetPreNotificationsAsync();
                var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == createFixed.CompanyId);
                var isValid = Utilities.ValidateDate(companyDate.OpeningDate, companyDate.ClosingDate, details.OpeningDate, details.ClosingDate);
                if (!isValid)
                {
                    return StatusCode(400, new { errors = new[] { "The year selected has to be within the financial year!!" } });
                }

                bool status = createFixed.IsCost ? true : false;
                var value = await _fixedAssetService.GetAmount(createFixed.TriBalanceId, status);

                if (status)
                {
                    if (createFixed.IsTransferCostRemoved)
                    {
                        var totalCost = createFixed.OpeningCost + createFixed.CostAddition - createFixed.CostDisposal - createFixed.TransferCost;
                        if (totalCost != value)
                        {
                            return StatusCode(400, new { errors = new[] { "Closing balance selected is not equal to your computataion" } });

                        }
                    }
                    else
                    {
                        var totalCost = createFixed.OpeningCost + createFixed.CostAddition - createFixed.CostDisposal + createFixed.TransferCost;
                        if (totalCost != value)
                        {
                            return StatusCode(400, new { errors = new[] { "Closing balance selected is not equal to your computataion" } });

                        }
                    }

                }
                else
                {
                    if (createFixed.IsTransferDepreciationRemoved)
                    {
                        var totalDepreciation = createFixed.OpeningDepreciation + createFixed.DepreciationAddition - createFixed.DepreciationDisposal - createFixed.TransferDepreciation;
                        if (totalDepreciation != value)
                        {
                            return StatusCode(400, new { errors = new[] { "Closing balance selected is not equal to your computataion" } });

                        }
                    }
                    else
                    {
                        var totalDepreciation = createFixed.OpeningDepreciation + createFixed.DepreciationAddition - createFixed.DepreciationDisposal + createFixed.TransferDepreciation;
                        if (totalDepreciation != value)
                        {
                            return StatusCode(400, new { errors = new[] { "Closing balance selected is not equal to your computataion" } });

                        }
                    }
                }

                if (createFixed == null)
                {
                    var error = new[] { "Bad Input !" };

                    return StatusCode(400, new { errors = new { error } });
                }
                if (createFixed.MappedCode == null)
                {
                    return BadRequest();
                }
                if (createFixed.YearId <= 0)
                {

                    return StatusCode(400, new { errors = new[] { "Please select a valid year" } });
                }

                if (createFixed.AssetId <= 0)
                {

                    return StatusCode(400, new { errors = new[] { "Please select a valid asset class" } });
                }

                if (createFixed.CompanyId == 0)
                {
                    return StatusCode(400, new { errors = new[] { "Please select a valid company" } });

                }

                await _fixedAssetService.SaveFixedAsset(createFixed);

                return Ok("saved successfully");

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);

                return StatusCode(500, new { errors = new[] { "Error Occured please try again later,please try again later..." } });
            }
        }

        [HttpPut("fixed-asset/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFixedAsset(int id)
        {
            await _utilitiesService.UnmapValue(id);
            return Ok("Item Unmapped");
        }


        [HttpDelete("delete-fixed-asset/{id}")]
        [Authorize]
        public async Task<IActionResult> FixedAsset(int id)
        {
            await _fixedAssetService.DeleteFixedAssetById(id);
            return Ok("Item Unmapped");
        }



        [HttpGet("{companyId}/{yearId}")]
        //[Authorize]
        public async Task<IActionResult> GetFixedAsset(int companyId, int yearId)
        {
            try
            {
                var details = await _utilitiesService.GetFinancialYearAsync(yearId);
                var companyDetails = await _utilitiesService.GetPreNotificationsAsync();
                var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == companyId);
                var isValid = Utilities.ValidateDate(companyDate.OpeningDate, companyDate.ClosingDate, details.OpeningDate, details.ClosingDate);

                if (yearId == 0)
                {
                    return StatusCode(400, new { errors = new[] { "Please select a Valid year" } });
                }
                var fixedAsset = await _fixedAssetService.GetFixedAssetsByCompany(companyId, yearId);
                if (fixedAsset == null)
                {
                    return StatusCode(404, new { errors = new[] { "Record not found at this time please try again later" } });
                }
                if (isValid)
                {
                    fixedAsset.CanDelete = true;
                }
                return Ok(fixedAsset);

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

    }
}