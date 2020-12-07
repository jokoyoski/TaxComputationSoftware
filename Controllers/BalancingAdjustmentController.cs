

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
            if(companyId <= 0 || string.IsNullOrEmpty(year)) return BadRequest("ComapnyId and Year are invalid");

            var response = await _balancingAdjustmentService.DisplayBalancingAdjustment(companyId, year);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBalancingAdjustment([FromForm] AddBalanceAdjustmentDto addBalanceAdjustmentDto)
        {
            if(addBalanceAdjustmentDto == null) return BadRequest("Invalid input");

            var response = await _balancingAdjustmentService.AddBalanceAdjustment(addBalanceAdjustmentDto);

            return Ok(response);
        }

        [HttpDelete("balancing-adjustment-year-bought/{Id}")]
        // [Authorize]
        public async Task<IActionResult> DeleteBalancingAdjustmentYearBought(int Id)
        {
            try
            {

                var balancingAdjusmentYearBought = await _balancingAdjustmentService.GetBalancingAdjustmentYearBoughtById(Id);
                if (balancingAdjusmentYearBought == null)
                {
                    return StatusCode(404, new { errors = new[] { "Balancing adjustment year bought not found!" } });
                }
                balancingAdjusmentYearBought.Id = Id;

                await _balancingAdjustmentService.DeleteBalancingAdjustmentYearBoughtAsync(balancingAdjusmentYearBought);

                return Ok("Balancicng adjustment year bought deleted successfully !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

    }
}