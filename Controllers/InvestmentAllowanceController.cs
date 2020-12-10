using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentAllowanceController : ControllerBase
    {
        private readonly ILogger<InvestmentAllowanceController> _logger;
        private readonly IFixedAssetService _fixedAssetService;
        private readonly IInvestmentAllowanceService _investmentAllowanceService;
        public InvestmentAllowanceController(ILogger<InvestmentAllowanceController> logger, IFixedAssetService fixedAssetService, IInvestmentAllowanceService investmentAllowanceService)
        {
            _logger = logger;
            _fixedAssetService = fixedAssetService;
            _investmentAllowanceService = investmentAllowanceService;
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> AddInvestmentAllowance(InvestmentAllowanceDto investmentAllowanceDto)
        {
            try
            {
                await _investmentAllowanceService.AddInvestmentAllowanceByAssetIdAndYearId(investmentAllowanceDto);
                return Ok("Record saved succesfully!");
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
