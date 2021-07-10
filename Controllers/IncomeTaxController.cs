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

namespace TaxComputationSoftware.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class IncomeTaxController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<IncomeTaxController> _logger;

        private readonly ITrialBalanceService _trialBalanceService;
        private readonly IIncomeTaxService _incomeTaxService;
        private readonly IMemoryCache _memoryCache;

        private readonly IUtilitiesService _utilitiesService;

        public IncomeTaxController(IEmailService emailService, ILogger<IncomeTaxController> logger, IMemoryCache memoryCache, IUtilitiesService utilitiesService, ITrialBalanceService trialBalanceService, IIncomeTaxService incomeTaxService)
        {
            _emailService = emailService;
            _logger = logger;
            _incomeTaxService = incomeTaxService;
            _trialBalanceService = trialBalanceService;
            _utilitiesService = utilitiesService;
            _memoryCache = memoryCache;
        }

        [HttpGet("{companyId}/{yearId}/{IsItLevyView}")]
        //[Authorize]
        public async Task<IActionResult> GetIncometax(int companyId, int yearId, bool IsItLevyView, bool isBringLossFoward)
        {

            var financialYear = await _utilitiesService.GetFinancialCompanyAsync(companyId);
            var financialYearRecord = financialYear.OrderByDescending(x => x.Id).FirstOrDefault();
            if (isBringLossFoward && financialYearRecord.Id != yearId)
            {
                return StatusCode(400, new { errors = new[] { "Please move the current Loss/unRelived and not previous UnRelieved/losses" } });
            }

            if (yearId == 0)
            {
                return StatusCode(400, new { errors = new[] { "Please select a Valid year" } });
            }
            try
            {
                var value = await _incomeTaxService.GetIncomeTax(companyId, yearId, IsItLevyView, isBringLossFoward);
                if (value == null)
                {
                    return StatusCode(400, new { errors = new[] { "Ensure You have an active capital allowance for this year!" } });
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



        [HttpPost("add-income-tax")]
        [Authorize]
        public async Task<IActionResult> AddIncomeTax(CreateIncomeTaxDto createIncomeTaxDto)
        {
            try
            {

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

                var details = await _utilitiesService.GetFinancialYearAsync(createIncomeTaxDto.YearId);
                var companyDetails = await _utilitiesService.GetPreNotificationsAsync();
                var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == createIncomeTaxDto.CompanyId);
                var itemModules = await _utilitiesService.GetFinancialCompanyAsync(createIncomeTaxDto.CompanyId);
                var m = itemModules.LastOrDefault();
                if (m.Id != details.Id)
                {
                    return StatusCode(400, new { errors = new[] { "This operation is not valid for previous tax years" } });

                }


                _incomeTaxService.SaveAllowableDisAllowable(createIncomeTaxDto);
                return Ok("Income tax created successfully");

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

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

    }
}