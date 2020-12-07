

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            var response = await _balancingAdjustmentService.DisplayBalancingAdjustment(companyId, year);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBalancingAdjustment([FromForm] AddBalanceAdjustmentDto addBalanceAdjustmentDto)
        {
            var response = await _balancingAdjustmentService.AddBalanceAdjustment(addBalanceAdjustmentDto);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBalancingAdjustmentYearBought(int Id)
        {
            var response = await _balancingAdjustmentService.DeleteBalancingAdjustmentYearBoughtAsync(Id);

            return Ok(response);
        }

    }
}