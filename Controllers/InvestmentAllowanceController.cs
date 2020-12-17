using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IInvestmentAllowanceService _investmentAllowanceService;
        public InvestmentAllowanceController(ILogger<InvestmentAllowanceController> logger, IMapper mapper, IInvestmentAllowanceService investmentAllowanceService)
        {
            _logger = logger;
            _mapper = mapper;
            _investmentAllowanceService = investmentAllowanceService;
        }

        [HttpPost("investment-allowance")]
        public async Task<IActionResult> AddInvestmentAllowance(InvestmentAllowanceDto investmentAllowanceDto)
        {
            try
            {
                
                var investmentAllowanceToAdd = _mapper.Map<InvestmentAllowance>(investmentAllowanceDto);
                investmentAllowanceToAdd.AssetId = investmentAllowanceDto.AssetId;
                investmentAllowanceToAdd.CompanyId = investmentAllowanceDto.CompanyId;
                investmentAllowanceToAdd.YearId = investmentAllowanceDto.YearId;

                await _investmentAllowanceService.AddInvestmentAllowanceAsync(investmentAllowanceToAdd);

                return Ok("Investment Allowance added successfully !!");

            }
            catch (Exception ex)
            {
                var error = new[] { "Error occured while trying to process your request please try again later !" };
                return StatusCode(500, new { errors = new { error } });
            }
        }

        [HttpDelete("investment-allowance/{Id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteInvestmentAllowance(int Id)
        {
            try
            {
               

                await _investmentAllowanceService.DeleteInvestmentAllowanceAsync(Id);

                return Ok("Investment Allowance deleted successfully !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpGet("{companyId}/{yearId}")]
        [Authorize]
        public async Task<IActionResult> GetInvestmentAllowanceByCompanyIdAndYearId(int companyId, int yearId)
        {

            if (yearId == 0)
            {
                return StatusCode(400, new { errors = new[] { "Please select a Valid year" } });
            }
            try
            {
                
                var investment = await _investmentAllowanceService.GetInvestmentAllowances(companyId, yearId);
                if (investment!=null)
                {
                    
                        return Ok(new { investment });
                    
                }
                return StatusCode(404, new { errors = new[] { "Record not found at this time please try again later" } });

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
