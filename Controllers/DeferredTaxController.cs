
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeferredTaxController : ControllerBase
    {

        private readonly IDeferredTaxService _deferredTaxService;
        private readonly ITrialBalanceService _trialBalanceService;
        private readonly ILogger<DeferredTaxController> _logger;
        private readonly IMemoryCache _memoryCache;
        public DeferredTaxController(IDeferredTaxService deferredTaxService, IMemoryCache memoryCache, ITrialBalanceService trialBalanceService, ILogger<DeferredTaxController> logger)
        {
            _deferredTaxService = deferredTaxService;
            _logger = logger;
            _trialBalanceService = trialBalanceService;
            _memoryCache = memoryCache;
        }


        [HttpGet]
        public async Task<IActionResult> GetDeferredTax(int companyId, string year)
        {

            try
            {
                var value = await _deferredTaxService.GetDeferredTax(companyId, int.Parse(year));

                return Ok(value);

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }


        }

        [HttpPost]
        public async Task<IActionResult> AddDeferredTax(CreateDeferredTax createDeferredTax)
        {

            try
            {
            
                var startDate = _memoryCache.Get<DateTime>(Constants.OpeningDate);
                var endDate = _memoryCache.Get<DateTime>(Constants.ClosingDate);
                var isValid = Utilities.ValidateDate(startDate, endDate, createDeferredTax.YearId);
                if (!isValid)
                {
                    return StatusCode(400, new { errors = new[] { "The year selected has to be within the financial year!!" } });
                }
                foreach (var j in createDeferredTax.TrialBalanceList)
                {
                    if (j.TrialBalanceId != 0)
                    {
                        var trialBalanceRecord = await _trialBalanceService.GetTrialBalanceById(j.TrialBalanceId);
                        if (trialBalanceRecord.IsCheck)
                        {
                            return StatusCode(400, new { errors = new[] { "One of the item selected has already been mapped, please reload" } });
                        }
                    }

                }

                var broughtFowardInfo = await _deferredTaxService.GetBroughtFoward(createDeferredTax.CompanyId);
               
                _deferredTaxService.SaveDeferredTax(createDeferredTax);
                return Ok("Saved Successfully!!!");

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