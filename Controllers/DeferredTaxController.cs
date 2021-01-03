
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public DeferredTaxController(IDeferredTaxService deferredTaxService, ITrialBalanceService trialBalanceService,ILogger<DeferredTaxController> logger)
        {
            _deferredTaxService = deferredTaxService;
            _logger = logger;
            _trialBalanceService=trialBalanceService;
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
                   foreach (var j in createDeferredTax.TrialBalanceList)
                {
                    var trialBalanceRecord = await _trialBalanceService.GetTrialBalanceById(j.TrialBalanceId);
                    if (trialBalanceRecord.IsCheck)
                    {
                        return StatusCode(400, new { errors = new[] { "One of the item selected has already been mapped, please reload" } });
                    }
                }

                if (createDeferredTax.YearId < DateTime.Now.Year)
                {
                    return StatusCode(400, new { errors = new[] { "Income Tax for Previous Year is not Alllowed!" } });
                }

                  var broughtFowardInfo = await _deferredTaxService.GetBroughtFoward(createDeferredTax.CompanyId);
                if (broughtFowardInfo != null)
                {
                    createDeferredTax.IsStarted=true;
                    if (broughtFowardInfo.IsStarted && createDeferredTax.DeferredTaxBroughtFoward > 0)
                    {
                        return StatusCode(400, new { errors = new[] { "The Deferred Tax Brought Foward is required once" } });
                    }
                }
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