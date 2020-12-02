﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinimumTaxController : ControllerBase
    {
        private readonly ILogger<ITLevyController> _logger;
        private readonly IProfitAndLossService _profitAndLossService;
        private readonly IMinimumTaxService _minimumTaxService;
        public MinimumTaxController(IProfitAndLossService profitAndLossService, IMinimumTaxService minimumTaxService, ILogger<ITLevyController> logger)
        {
            _profitAndLossService = profitAndLossService;
            _minimumTaxService = minimumTaxService;
            _logger = logger;
        }

        [HttpGet("{companyId}/{yearId}")]
        [Authorize]
        public async Task<IActionResult> GetITLevy(int companyId, int yearId)
        {

            if (yearId == 0)
            {
                return StatusCode(400, new { errors = new[] { "Please select a Valid year" } });
            }
            try
            {
                var itLevy = await _minimumTaxService.GetMinimumTaxByCompanyIdAndYear(companyId, yearId);

                return Ok(itLevy);

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
