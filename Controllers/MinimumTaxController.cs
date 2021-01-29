using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinimumTaxController : ControllerBase
    {
        private readonly ILogger<ITLevyController> _logger;
        private readonly IEmailService _emailService;
        private readonly IProfitAndLossService _profitAndLossService;
        private readonly IMinimumTaxService _minimumTaxService;
        public MinimumTaxController(IEmailService emailService, IProfitAndLossService profitAndLossService, IMinimumTaxService minimumTaxService, ILogger<ITLevyController> logger)
        {
            _emailService = emailService;
            _profitAndLossService = profitAndLossService;
            _minimumTaxService = minimumTaxService;
            _logger = logger;
        }

        [HttpGet("{companyId}/{yearId}")]
        [Authorize]
        public async Task<IActionResult> GetMinimumTax(int companyId, int yearId)
        {
        
            if (yearId == 0)
            {
                return StatusCode(400, new { errors = new[] { "Please select a Valid year" } });
            }
            try
            {
                var value = await _profitAndLossService.GetMinimumTax(companyId, yearId);
                decimal percentage = (decimal)1 / 100;     //annual percentage rate
                if (value!= null)
                {
                    var turnOver = decimal.Parse(value.Revenue) + decimal.Parse(value.OtherIncome);
                    var percent = percentage * turnOver;
                    return Ok(new { turnOver = turnOver, fivePercentTurnOver =  percent });
                }
                else
                {
                    return StatusCode(404, new { errors = new[] { "Record not found at this time please try again later" } });

                }


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
        public async Task<IActionResult> AddOldMinimumTax(AddMinimumTaxDto addMinimumTaxDto)
        {
            if(addMinimumTaxDto == null) return BadRequest("");

            try
            {
                var response = await _minimumTaxService.AddMinimumTax(addMinimumTaxDto);
                
                return Ok(response);
            }
            catch(Exception e)
            {

                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, e.Message);

                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });
            }

            return null;
        }
    
    }
}
