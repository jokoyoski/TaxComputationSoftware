using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TrialBalanceController : ControllerBase
    {
        private readonly ITrialBalanceService _trialBalanceService;
        private readonly ILogger<TrialBalanceController> _logger;

        private readonly IUtilitiesService _utilityService;
        private readonly IMemoryCache _memoryCache;
        private IMemoryCache _cache;

        public TrialBalanceController(ITrialBalanceService trialBalanceService, IMemoryCache memoryCache, IUtilitiesService utilityService, ILogger<TrialBalanceController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _trialBalanceService = trialBalanceService;
            _cache = cache;
            _utilityService = utilityService;
            _memoryCache = memoryCache;
        }

        [HttpGet()]
     [Authorize]
        public async Task<IActionResult> GetTrialBalance(int companyId, int yearId)
        {
          
            var companyDetails = await _utilityService.GetPreNotificationsAsync();
            var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == companyId);
            _cache.Set(Constants.CompanyId, companyDate.CompanyId);
            _cache.Set(Constants.OpeningDate, companyDate.OpeningDate);
            _cache.Set(Constants.ClosingDate, companyDate.ClosingDate);
            if (companyId <= 0 && yearId <= 0) return BadRequest($"{companyId} and {yearId} are required");

            try
            {
                return Ok(await _trialBalanceService.GetTrialBalance(companyId, yearId));

            }
            catch (Exception ex)
            {
                // var error = ex.Message;
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });


            }
        }

        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> UploadTrialBalance([FromForm] UploadTrackTrialBalanceDto excel)
        {
            try
            {

               
                var details = await _utilityService.GetFinancialYearAsync(excel.YearId);
                var startDate = _memoryCache.Get<DateTime>(Constants.OpeningDate);
                var endDate = _memoryCache.Get<DateTime>(Constants.ClosingDate);
                var isValid = Utilities.ValidateDate(startDate, endDate, details.OpeningDate, details.ClosingDate);


                if (!isValid)
                {
                    return StatusCode(400, new { errors = new[] { "The year selected has to be within the financial year!!" } });
                }

                await _trialBalanceService.UploadTrialBalance(excel);

                return Ok($"{excel.File.FileName} successfully upload");

            }
            catch (Exception ex)
            {
                // var error = ex.Message;
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }
    }
}