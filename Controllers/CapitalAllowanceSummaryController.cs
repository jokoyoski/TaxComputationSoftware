using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Interfaces;


namespace TaxComputationSoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitalAllowanceSummaryController : ControllerBase
    {
        private readonly ICapitalAllowanceService _capitalAllowanceService;
        public CapitalAllowanceSummaryController(ICapitalAllowanceService capitalAllowanceService)
        {
            _capitalAllowanceService = capitalAllowanceService;

        }
        [HttpGet("companyId")]
        [Authorize]

        public async Task<IActionResult> Allowance(int companyId)
        {
            var value = await _capitalAllowanceService.GetCapitalAllowanceSummaryByCompanyId(companyId);
            if (value == null)
            {
                return NotFound(new { errors = new[] { "Record not found!!!" } });
            }

            return Ok(value);
        }

    }


}


