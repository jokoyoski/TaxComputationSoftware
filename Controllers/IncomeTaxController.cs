using System;
using System.Collections.Generic;
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

namespace TaxComputationSoftware.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class IncomeTaxController : ControllerBase
    {
        private readonly ILogger<IncomeTaxController> _logger;

        private readonly ITrialBalanceService _trialBalanceService;
        private readonly IIncomeTaxService _incomeTaxService;
        private readonly IMemoryCache _memoryCache;

        public IncomeTaxController(ILogger<IncomeTaxController> logger, IMemoryCache memoryCache, ITrialBalanceService trialBalanceService, IIncomeTaxService incomeTaxService)
        {
            _logger = logger;
            _incomeTaxService = incomeTaxService;
            _trialBalanceService = trialBalanceService;
            _memoryCache = memoryCache;
        }

        [HttpGet("{companyId}/{yearId}/{IsItLevyView}")]
        [Authorize]
        public async Task<IActionResult> GetIncometax(int companyId, int yearId, bool IsItLevyView)
        {

            if (yearId == 0)
            {
                return StatusCode(400, new { errors = new[] { "Please select a Valid year" } });
            }
            try
            {
                var value = await _incomeTaxService.GetIncomeTax(companyId, yearId, IsItLevyView);
                return Ok(value);

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }



        [HttpPost("add-income-tax")]
        [Authorize]
        public async Task<IActionResult> AddIncomeTax(CreateIncomeTaxDto createIncomeTaxDto)
        {
            try
            {
                if (createIncomeTaxDto.LossBroughtFoward > 0)
                {
                    return StatusCode(400, new { errors = new[] { "Since it is a loss brought foward, a negative value is needed!!" } });
                }

                if (createIncomeTaxDto.TypeId == 0)
                {
                    foreach (var j in createIncomeTaxDto.IncomeList)
                    {

                        if (j.IsCredit && !j.IsBoth && !j.IsDebit)
                        {
                            return StatusCode(400, new { errors = new[] { "Debit Values only are required for DisAlllowable" } });
                        }
                    }

                }

                if (createIncomeTaxDto.TypeId == 1)
                {
                    foreach (var j in createIncomeTaxDto.IncomeList)
                    {

                        if (!j.IsCredit && !j.IsBoth && j.IsDebit)
                        {
                            return StatusCode(400, new { errors = new[] { "Credit Values only are required for Allowable" } });
                        }
                    }
                };

                foreach (var j in createIncomeTaxDto.IncomeList)
                {
                    if (j.TrialBalanceId > 0)
                    {
                        var trialBalanceRecord = await _trialBalanceService.GetTrialBalanceById(j.TrialBalanceId);
                        if (trialBalanceRecord.IsCheck)
                        {
                            return StatusCode(400, new { errors = new[] { "One of the item selected has already been mapped, please reload" } });
                        }
                    }


                }

                var startDate = _memoryCache.Get<DateTime>(Constants.OpeningDate);
                var endDate = _memoryCache.Get<DateTime>(Constants.ClosingDate);
                var isValid = Utilities.ValidateDate(startDate, endDate, createIncomeTaxDto.YearId);

                if (!isValid)
                {
                    return StatusCode(400, new { errors = new[] { "The year selected has to be within the financial year!!" } });
                }
                var broughtFowardInfo = await _incomeTaxService.GetBroughtFoward(createIncomeTaxDto.CompanyId);
                if (broughtFowardInfo != null)
                {
                    if (broughtFowardInfo.IsStarted && createIncomeTaxDto.LossBroughtFoward > 0 || createIncomeTaxDto.UnrelievedCapitalAllowanceBroughtFoward > 0)
                    {
                        return StatusCode(400, new { errors = new[] { "The LossBf/UnRelievedBf is required once" } });
                    }
                }

                _incomeTaxService.SaveAllowableDisAllowable(createIncomeTaxDto);
                return Ok("Income tax created successfully");

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }




        [HttpDelete("remove-allowable/disallowable/{id}")]
        [Authorize]
        public async Task<IActionResult> RemoveItem(int id)
        {
            try
            {

                _incomeTaxService.DeleteAllowableDisAllowable(id);
                return Ok("Income tax deleted successfully");

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