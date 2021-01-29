
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IEmailService _emailService;
        private readonly ITrialBalanceService _trialBalanceService;
        private readonly ILogger<DeferredTaxController> _logger;

        private readonly IUtilitiesService _utilitiesService;
        private readonly IMemoryCache _memoryCache;
        public DeferredTaxController(IDeferredTaxService deferredTaxService, IEmailService emailService, IMemoryCache memoryCache, IUtilitiesService utilitiesService, ITrialBalanceService trialBalanceService, ILogger<DeferredTaxController> logger)
        {
            _deferredTaxService = deferredTaxService;
            _emailService = emailService;
            _logger = logger;
            _trialBalanceService = trialBalanceService;
            _memoryCache = memoryCache;
            _utilitiesService = utilitiesService;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDeferredTax(int companyId, string year, bool IsBringDeferredTaxFoward)
        {

            try
            {
                var details = await _utilitiesService.GetFinancialYearAsync();
                if (details.FirstOrDefault().Id == int.Parse(year))
                {
                    return StatusCode(400, new { errors = new[] { "Invalid Year selected" } });
                }
                if (IsBringDeferredTaxFoward && details.LastOrDefault().Id != int.Parse(year))
                {
                    return StatusCode(400, new { errors = new[] { "Please move the current Deferred tax and not previous deferred tax" } });
                }
                var value = await _deferredTaxService.GetDeferredTax(companyId, int.Parse(year), IsBringDeferredTaxFoward);

                return Ok(value);

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
                
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }


        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddDeferredTax(CreateDeferredTax createDeferredTax)
        {

            try
            {

                var details = await _utilitiesService.GetFinancialYearAsync(createDeferredTax.YearId);
                var companyDetails = await _utilitiesService.GetPreNotificationsAsync();
                var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == createDeferredTax.CompanyId);
                var isValid = Utilities.ValidateDate(companyDate.OpeningDate, companyDate.ClosingDate, details.OpeningDate, details.ClosingDate);
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

                //  var broughtFowardInfo = await _deferredTaxService.GetBroughtFoward(createDeferredTax.CompanyId);

                _deferredTaxService.SaveDeferredTax(createDeferredTax);
                return Ok("Saved Successfully!!!");

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);


                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }

        }

    }
}