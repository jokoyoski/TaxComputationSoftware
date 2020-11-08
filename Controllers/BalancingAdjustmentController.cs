

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Dto;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalancingAdjustmentController : ControllerBase
    {
        private readonly IBalancingAdjustmentService _balancingAdjustmentService;

        public BalancingAdjustmentController(IBalancingAdjustmentService balancingAdjustmentService)
        {
            _balancingAdjustmentService = balancingAdjustmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalancingAdjustment(int companyId, string year)
        {
            if(companyId <= 0 || string.IsNullOrEmpty(year)) return BadRequest("ComapnyId and Year are invalid");

            var response = await _balancingAdjustmentService.DisplayBalancingAdjustment(companyId, year);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBalancingAdjustment(AddBalanceAdjustmentDto addBalanceAdjustmentDto)
        {
            if(addBalanceAdjustmentDto == null) return BadRequest("Invalid input");

            var response = await _balancingAdjustmentService.AddBalanceAdjustment(addBalanceAdjustmentDto);

            return Ok(response);
        }
    }
}