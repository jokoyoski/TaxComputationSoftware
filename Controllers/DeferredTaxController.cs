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
                var financialYear = await _utilitiesService.GetFinancialCompanyAsync(companyId);
                var financialYearRecord = financialYear.OrderByDescending(x => x.Id).FirstOrDefault();
                if (IsBringDeferredTaxFoward && financialYearRecord.Id != int.Parse(year))
                {
                    return StatusCode(400, new { errors = new[] { "Please move the current Deferred tax and not previous deferred tax" } });
                }
                var value = await _deferredTaxService.GetDeferredTax(companyId, int.Parse(year), IsBringDeferredTaxFoward);
                if(value==null){
                      return StatusCode(400, new { errors = new[] { "No Active Unabsorbed from Income Tax to use" } });
                }
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

      
    }
}