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

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitAndLossController : ControllerBase
    {
        private readonly ILogger<ProfitAndLossController> _logger;
        private readonly IProfitAndLossService _profitAndLossService;
        public ProfitAndLossController(IProfitAndLossService profitAndLossService, ILogger<ProfitAndLossController> logger)
        {
            _profitAndLossService = profitAndLossService;
            _logger = logger;
        }



        [HttpPost()]
        //[Authorize]
        public async Task<IActionResult> CreateProfitandLoss(CreateProfitAndLoss profitAndLoss)
        {
            try
            {


               

                 return Ok("saved successfully");

            }
            catch (Exception ex)
            {
                // var error = ex.Message;
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
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
                List<ProfitAndLossDto> profitAndLoss = new List<ProfitAndLossDto>();
                profitAndLoss.Add(new ProfitAndLossDto
                {

                    Revenue = "3000",
                    CostOfSales = "(300000)",
                    GrossLoss = "(30585850.0)",
                    OtherOperatingIncome = "0",
                    OtherOperatingGain = "2900",
                    OperatingExpense = "(202002020)",
                    LossBeforeTaxation = "(27777)"


                });

                profitAndLoss.Add(new ProfitAndLossDto
                {

                    Revenue = "3000",
                    CostOfSales = "(300000)",
                    GrossLoss = "(30585850.0)",
                    OtherOperatingIncome = "0",
                    OtherOperatingGain = "2900",
                    OperatingExpense = "(202002020)",
                    LossBeforeTaxation = "(27777)"


                });


                profitAndLoss.Add(new ProfitAndLossDto
                {

                    Revenue = "3000",
                    CostOfSales = "(300000)",
                    GrossLoss = "(30585850.0)",
                    OtherOperatingIncome = "0",
                    OtherOperatingGain = "2900",
                    OperatingExpense = "(202002020)",
                    LossBeforeTaxation = "(27777)"


                });
               
                return Ok(profitAndLoss);

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
