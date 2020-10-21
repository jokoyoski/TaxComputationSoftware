using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class TrialBalanceController : ControllerBase {
        private readonly ITrialBalanceService _trialBalanceService;
        private readonly ILogger<TrialBalanceController> _logger;

        public TrialBalanceController (ITrialBalanceService trialBalanceService, ILogger<TrialBalanceController> logger) {
            _logger = logger;
            _trialBalanceService = trialBalanceService;
        }

        [HttpGet ()]
        public async Task<IActionResult> GetTrialBalance (int companyId, int yearId) {

            if (companyId <= 0 && yearId <= 0) return BadRequest ($"{companyId} and {yearId} are required");

            try {
                return Ok (await _trialBalanceService.GetTrialBalance (companyId, yearId));

            } catch (Exception ex) {
                // var error = ex.Message;
                var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode (500, "Error Occured please try again later,please try again later...");
            }
        }

        [HttpPost ()]
        public async Task<IActionResult> UploadTrialBalance ([FromForm] UploadTrackTrialBalanceDto excel) {
            try {
                await _trialBalanceService.UploadTrialBalance (excel);

                return Ok ($"{excel.File.FileName} successfully upload");

            } catch (Exception ex) {
                // var error = ex.Message;
                var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode (500, $"Error Occured please try again later,please try again later...{ex.Message}");
            }
        }
    }
}