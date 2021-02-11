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
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitAndLossController : ControllerBase
    {
        private readonly ILogger<ProfitAndLossController> _logger;
        private readonly IEmailService _emailService;
        private readonly IProfitAndLossService _profitAndLossService;
        private readonly ITrialBalanceService _trialBalanceService;
        private readonly IMemoryCache _memoryCache;
        private IUtilitiesService _utilitiesServices;
        public ProfitAndLossController(IEmailService emailService, IProfitAndLossService profitAndLossService, IUtilitiesService utilitiesServices, ITrialBalanceService trialBalanceService, IMemoryCache memoryCache, ILogger<ProfitAndLossController> logger)
        {
            _emailService = emailService;
            _profitAndLossService = profitAndLossService;
            _trialBalanceService = trialBalanceService;
            _logger = logger;
            _memoryCache = memoryCache;
            _utilitiesServices = utilitiesServices;
        }



        [HttpPost()]
        //  [Authorize]
        public async Task<IActionResult> CreateProfitandLoss(CreateProfitAndLoss profitAndLoss)
        {
            try
            {

                foreach (var j in profitAndLoss.TrialBalanceList)
                {
                    var trialBalanceRecord = await _trialBalanceService.GetTrialBalanceById(j.TrialBalanceId);
                    if (trialBalanceRecord.IsCheck)
                    {
                        return StatusCode(400, new { errors = new[] { "One of the item selected has already been mapped, please reload" } });
                    }
                }
                if (profitAndLoss.ProfitAndLossId != 5)
                {
                    var value = await _profitAndLossService.ValidateProfitAndLossInput(profitAndLoss.TrialBalanceList, profitAndLoss.CompanyId, profitAndLoss.YearId, profitAndLoss.ProfitAndLossId);
                    if (!value)
                    {
                        return StatusCode(400, new { errors = new[] { "Your total selections cant be  a negative!!!" } });
                    }

                }

                var details = await _utilitiesServices.GetFinancialYearAsync(profitAndLoss.YearId);
                var companyDetails = await _utilitiesServices.GetPreNotificationsAsync();
                var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == profitAndLoss.CompanyId);
                int taxYear = int.Parse(details.Name);
                if (companyDate.ClosingDate.Year + 1 != taxYear)
                {
                    return StatusCode(400, new { errors = new[] { "This operation is not valid for previous tax years"} });
  
                }

                await _profitAndLossService.SaveProfitsAndLoss(profitAndLoss);
                return Ok("saved successfully");

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



        [HttpGet("{companyId}/{yearId}")]
        [Authorize]
        public async Task<IActionResult> GetProftAndLoss(int companyId, int yearId)
        {

            if (yearId == 0)
            {
                return StatusCode(400, new { errors = new[] { "Please select a Valid year" } });
            }

            try
            {
                var profitAndLoss = await _profitAndLossService.GetProfitAndLossByCompanyIdAndYear(companyId, yearId);
                if (profitAndLoss.Count <= 0)
                {
                    return StatusCode(404, new { errors = new[] { "Record not found at this time please try again later" } });
                }
                return Ok(profitAndLoss);

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
