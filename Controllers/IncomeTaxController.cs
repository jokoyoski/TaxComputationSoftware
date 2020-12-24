using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationSoftware.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class IncomeTaxController : ControllerBase
    {
        private readonly ILogger<IncomeTaxController> _logger;
        private readonly IIncomeTaxService _incomeTaxService;
        public IncomeTaxController(ILogger<IncomeTaxController> logger,IIncomeTaxService incomeTaxService)
        {
            _logger = logger;
            _incomeTaxService=incomeTaxService;
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

                 var value= await _incomeTaxService.GetIncomeTax(companyId,yearId,IsItLevyView);

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