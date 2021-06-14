using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentAllowanceController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<InvestmentAllowanceController> _logger;
        private readonly IMapper _mapper;
        private readonly IInvestmentAllowanceService _investmentAllowanceService;

        private readonly IUtilitiesService _utilitiesService;

        private readonly IMemoryCache _memoryCache;
        public InvestmentAllowanceController(IEmailService emailService, ILogger<InvestmentAllowanceController> logger, IUtilitiesService utilitiesService, IMemoryCache memoryCache, IMapper mapper, IInvestmentAllowanceService investmentAllowanceService)
        {
            _emailService = emailService;
            _logger = logger;
            _mapper = mapper;
            _investmentAllowanceService = investmentAllowanceService;
            _utilitiesService = utilitiesService;
            _memoryCache = memoryCache;
        }

        [HttpPost("investment-allowance")]
        [Authorize]
        public async Task<IActionResult> AddInvestmentAllowance(InvestmentAllowanceDto investmentAllowanceDto)
        {
            try
            {

                var details = await _utilitiesService.GetFinancialYearAsync(investmentAllowanceDto.YearId);
                var companyDetails = await _utilitiesService.GetPreNotificationsAsync();
                var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == investmentAllowanceDto.CompanyId);
                int taxYear = int.Parse(details.Name);
                var itemModules = await _utilitiesService.GetFinancialCompanyAsync(investmentAllowanceDto.CompanyId);
                var m = itemModules.OrderByDescending(x => x.Id).FirstOrDefault();
                if (m.Id != details.Id)
                {
                    return StatusCode(400, new { errors = new[] { "This operation is not valid for previous tax years" } });

                }

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

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);


                return StatusCode(500, new { errors = new { error } });
            }
        }

        [HttpDelete("investment-allowance/{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteInvestmentAllowance(int Id)
        {
            try
            {

                await _investmentAllowanceService.DeleteInvestmentAllowanceAsync(Id);

                return Ok("Investment Allowance deleted successfully !!");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

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
                if (investment != null)
                {

                    return Ok(new { investment });

                }
                return StatusCode(404, new { errors = new[] { "Record not found at this time please try again later" } });

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
