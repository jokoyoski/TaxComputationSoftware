using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitalAllowanceController : ControllerBase
    {
        private readonly ICapitalAllowanceService _capitalAllowanceService;
        private readonly ILogger<CapitalAllowanceController> _logger;
        public CapitalAllowanceController(ICapitalAllowanceService capitalAllowanceService, ILogger<CapitalAllowanceController> logger)
        {
            _capitalAllowanceService = capitalAllowanceService;
            _logger = logger;
        }


        [HttpPost]
        [Authorize]

        public async Task<IActionResult> SaveCapitalAllowance(CapitalAllowance capitalAllowance)
        {
            try
            {
                capitalAllowance.NumberOfYearsAvailable=8;
                if (capitalAllowance.Initial > 0)
                {
                    return BadRequest(new { errors = new[] { "Asset cannot have Initial Item" } });
                }
                if (capitalAllowance.Addition > 0)
                {
                    return BadRequest(new { errors = new[] { "Asset cannot have Addition" } });
                }
                if (capitalAllowance.Disposal > 0)
                {
                    return BadRequest(new { errors = new[] { "Calculate disposal from Balancing Adjustment" } });
                }

                var record = await _capitalAllowanceService.SaveCapitalAllowance(capitalAllowance);
                if (record > 0)
                {
                    return Ok("Record saved succesfully!");
                }
                return BadRequest(new { errors = new[] { "Could not save the record, please try again later !!" } });
            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }


        [HttpGet("{companyId}/{assetId}")]
        [Authorize]
        public async Task<IActionResult> GetCapitalAllowance(int companyId, int assetId)
        {
            try
            {
                if (assetId == 0)
                {
                    return StatusCode(400, new { errors = new[] { "Please select an asset" } });
                }
                var record = await _capitalAllowanceService.GetCapitalAllowance(assetId, companyId);

                if (record.capitalAllowances == null)
                {
                    return NotFound(new { errors = new[] { "Record not found!!!" } });
                }
                return Ok(record);

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCapitalAllowance(int id)
        {
           return Ok("deleted successfully!!!!");
        }



    }
}
