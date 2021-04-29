using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TrialBalanceController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ITrialBalanceService _trialBalanceService;
        private readonly ILogger<TrialBalanceController> _logger;

        private readonly IUtilitiesService _utilityService;
        private readonly IMemoryCache _memoryCache;
        private IMemoryCache _cache;

        public TrialBalanceController(IEmailService emailService, ITrialBalanceService trialBalanceService, IMemoryCache memoryCache, IUtilitiesService utilityService, ILogger<TrialBalanceController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _emailService = emailService;
            _trialBalanceService = trialBalanceService;
            _cache = cache;
            _utilityService = utilityService;
            _memoryCache = memoryCache;
        }

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetTrialBalance(int companyId, int yearId)
        {


            if (companyId <= 0 && yearId <= 0) return BadRequest($"{companyId} and {yearId} are required");

            try
            {
                var value = await _trialBalanceService.GetTrialBalance(companyId, yearId);
                if (value == null)
                {
                    var record = new List<TrialBalance>(){
                     new TrialBalance{
                         AccountId="12222",
                         Item="NO TRIAL BALANCE FOR THIS YEAR",
                         Debit=0,
                         Credit=0
                     }
                    };
                    return Ok(record);
                }

                return Ok(value);


            }
            catch (Exception ex)
            {
                // var error = ex.Message;
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

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
                var companyDetails = await _utilityService.GetPreNotificationsAsync();
                var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == excel.CompanyId);
                int taxYear = int.Parse(details.Name);
                if (companyDate.ClosingDate.Year + 1 != taxYear)
                {
                    return StatusCode(400, new { errors = new[] { "This operation is not valid for previous tax years"} });
  
                }
                await _trialBalanceService.UploadTrialBalance(excel);
                return Ok($"{excel.File.FileName} successfully upload");

            }
            catch (Exception ex)
            {
                // var error = ex.Message;
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }
   

        [HttpGet("doownload")]
        public async Task<IActionResult> DownloadOldMinimumTax(int companyId, int yearId)
        {
            if(companyId <= 0) return BadRequest($"Invalid companyId: {companyId}");

            if(yearId <= 0) return BadRequest($"Invalid yearId: {yearId}");

            var item = await _trialBalanceService.DownloadExcel(companyId, yearId);

            if(item == null) return NotFound("File not found");

            return File(item, "application/octet-stream", "Sample.csv");
        }
   
    }
}